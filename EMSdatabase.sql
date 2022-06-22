create database ElectionMS;

-------Tables------------

create table usr(
	id int primary key identity(1,1),
	gov_id varchar(50) not null unique,
	f_name varchar(50) not null,
	l_name varchar(50) not null,
	region varchar(50),
	voting_stat int,
	elid int foreign key references election_info(id) ON UPDATE CASCADE
)


create table loginn(
	id int identity(1,1),
	gov_id  varchar(50) not null unique foreign key references usr(gov_id) ON UPDATE CASCADE ON DELETE CASCADE,
	psswd varchar(256) not null,
	acct_type int not null,
	acct_stat int default 1
)

create table election_info(
	id int primary key identity(1000,1),
	title varchar(max) not null,
	s_date date not null,
	s_time time not null,
	e_date date not null,
	e_time time not null
)

create table candidate(
	id int primary key identity(10000,1),
	gov_id varchar(50) not null unique,
	election_id int foreign key references election_info(id) ON UPDATE CASCADE,
	f_name varchar(50) not null,
	l_name varchar(50) not null,
	acct_status int default 1,
	p_party varchar(50) not null,
	region varchar(50) not null,
	descr varchar(max) not null,
	photo image not null
)


create table ballout(
	id uniqueidentifier primary key,
	election_id int foreign key references election_info(id) ON UPDATE CASCADE,
	cid varchar(50) foreign key references candidate(gov_id)
)


create table seckey(
	rn int identity(1,1),
	id uniqueidentifier primary key default newid(),
	x varchar 
)

create table report(
	id int primary key identity(1,1),
	cid varchar(50) foreign key references candidate(gov_id),
	Eid int foreign key references election_info(id) ON UPDATE CASCADE,
	num int not null default 1,
	region varchar(50) not null
)
-----Procedures--------

--register candidate--
create procedure reg_cand @govid varchar(50),@elid int,@fn varchar(50),@ln varchar(50),@pp varchar(50),@reg varchar(50),@photo image,@desc varchar(max)
as
insert into candidate(gov_id,election_id,f_name,l_name,p_party,region,descr,photo)
values(@govid,@elid,@fn,@ln,@pp,@reg,@desc,@photo)


--deactivate candidate--
create procedure deac_can @id varchar(50)
as
update candidate
set acct_status = 0
where gov_id = @id

--activate candidate--
create procedure ac_can @id varchar(50)
as
update candidate
set acct_status = 1
where gov_id = @id

--register voter--
create procedure reg_voter @fn varchar(50),@ln varchar(50),@govid varchar(50),@password varchar(256),@reg varchar(50),@elid int
as
insert into usr(gov_id,f_name,l_name,region,voting_stat,elid)
values(@govid,@fn,@ln,@reg,0,@elid)
insert into loginn(gov_id,psswd,acct_type)
values(@govid,@password,1)

--deactivate user--
create procedure deac_usr @gov_id varchar(50)
as
update loginn
set acct_stat = 0
where gov_id = @gov_id

--activate user--
create procedure ac_usr @gov_id varchar(50)
as
update loginn
set acct_stat = 1
where gov_id = @gov_id

--update user--
create procedure upuser @fn varchar(50),@ln varchar(50),@govid varchar(50),@passwd varchar(256),@region varchar(50)
as
update usr
set f_name = @fn,
 l_name = @ln,
 gov_id = @govid,
 region = @region
where gov_id =@govid
update loginn
set psswd = @passwd
where gov_id = @govid

--add admin--
create procedure addadmin @fn varchar(50),@ln varchar(50),@gov_id varchar(50),@psswd varchar(256)
as
insert into usr(gov_id,f_name,l_name)
values(@gov_id,@fn,@ln)
insert into loginn(gov_id,psswd,acct_type)
values(@gov_id,@psswd,0)


--add election--
create procedure add_elec @title varchar(max),@sdate date,@stime time,@edate date,@etime time
as
insert into election_info(title,s_date,s_time,e_date,e_time)
values(@title,@sdate,@stime,@edate,@etime)

--check login--
create procedure chklogin @govid varchar(50),@psswd varchar(256)
as
select * from loginn where gov_id = @govid and psswd = @psswd

--Deactivate data for user--
create procedure deactUsrvi @gov_id varchar(50)
as
select gov_id as 'Govt ID',f_name + ' ' + l_name as 'Full Name' from usr where gov_id = @gov_id

--Deactivate data for Candidate--
create procedure deactCanvi @gov_id varchar(50)
as
select gov_id as 'Govt ID',f_name + ' ' + l_name as 'Full Name' from candidate where gov_id = @gov_id

--Update view--
create procedure upview @gov_id varchar(50)
as
select usr.f_name,usr.l_name,usr.gov_id,usr.region,loginn.acct_type,loginn.psswd
from usr
cross join loginn
where usr.gov_id = @gov_id and loginn.gov_id = @gov_id

--Data for the voting page--
create procedure voda @gov_id varchar(50)
as
select * from usr where gov_id = @gov_id

--Candidate list in the voter page--
create procedure voter_choice @region varchar(50),@elid int
as
select gov_id as 'Govt ID', f_name as 'First Name',l_name as 'Last Name',p_party as 'P.Party',region as 'Region' from vovi
where region = @region and
election_id = @elid

--view for the voter--
create view vovi
as 
select election_id,gov_id, f_name,l_name,p_party,region from candidate
where acct_status = 1

--check voting status--
create procedure vcheck @govid varchar(50)
as
select voting_stat from usr
where gov_id = @govid

--load for finald--
create procedure final @govid varchar(50)
as 
select f_name,l_name,p_party,descr,photo from candidate
where gov_id = @govid

--generate secrete key--
create procedure gensec
as
insert into seckey(x)values(NULL)

--select last generated sec key--
create procedure lskey
as 
select top 1 * from seckey
order by rn desc

--check the existance of a key--
create procedure chksec @id uniqueidentifier
as
select * from seckey
where id = @id 

--insert to ballot--
create procedure inscan @scode uniqueidentifier,@eid int,@cid varchar(50)
as
insert into ballout(id,election_id,cid)
values(@scode,@eid,@cid)

--voter update--
create procedure finish @govid varchar(50)
as
update usr
set voting_stat = 1
where gov_id = @govid
update loginn
set acct_stat = 0
where gov_id = @govid

--update elect--
create procedure upreport @cid varchar(50),@n int
as
update report 
set num = @n
where cid = @cid

--insert to report first time--
create procedure infr @cid varchar(50),@eid int,@region varchar(50)
as
insert into report(cid,Eid,region)values(@cid,@eid,@region)

--check for existance--
create procedure cir @cid varchar(50)
as
select * from report
where cid = @cid

--Datagridview view--
create view rsv
as
select f_name,l_name,candidate.region,num ,election_id,p_party
from candidate
cross join report
where candidate.gov_id = report.cid

--Data grid view Results --
create procedure result @reg varchar(50),@elid int
as
select f_name as 'First Name',l_name as 'Last Name',region as 'Region',p_party as 'Political Party',num as 'Result'
from rsv
where region = @reg and election_id = @elid
order by num desc

--Trigger to prevent deletion of voice ballout--
create trigger prev_bal_del on ballout 
for delete
as
begin
if exists (select * from deleted)
begin 
rollback;
print('Voter Ballout can not be deleted.')
end
end

--test--
exec addadmin @fn = 'admin',@ln = 'admin',@gov_id = 'admin',@psswd ='8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918'

