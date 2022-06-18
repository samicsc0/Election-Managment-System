using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;

namespace Election_MS
{
    internal class userClass
    {
        public String govid { get; set; }
        public String fname { get; set; }
        public string lname { get; set; }
        public String username { get; set; }
        public String psswd { get; set; }
        public int acctype  { get; set;}
        public string region { get; set; }
        public int vstat { get; set; }
        public int elid { get; private set; }
        public int stat { get; set; }

        static string constring = ConfigurationManager.ConnectionStrings["datab"].ConnectionString;
        
        /*      Login       */
        public userClass login(userClass u) {
            SqlConnection conn = new SqlConnection(constring);
            try
            {
                userClass v = new userClass();
                SqlCommand cmd = new SqlCommand("exec chklogin @govid = '"+u.govid+"',@psswd = '"+u.psswd+"'", conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    v.govid = (string)reader[1];
                    v.acctype = (int)reader[3];
                    v.stat = (int)reader[4];
                    return v;
                }
                else
                    return null;
            }catch (Exception ex)
            {
                return null;
            }
            finally { conn.Close(); }
        }

        /*      Candidate Registration      */

        public  int regcan(Candidate c)
        {
            SqlConnection conn = new SqlConnection(constring);
            try
            {
                SqlCommand cmd = new SqlCommand("exec reg_cand @govid = '"+c.govid+"', @elid = '"+c.elecid+"', @fn = '"+c.fname+"', @ln = '"+c.lname+"', @pp = '"+c.polp+"', @reg = '"+c.region+"', @photo = '"+c.img+"', @desc = '"+c.desc+"'",conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
            finally { conn.Close(); }
        }

        /*      Schedule an Election        */

        public int scheduleElection(Election e)
        {
            SqlConnection conn = new SqlConnection(constring);
            try
            {
                SqlCommand cmd = new SqlCommand("exec add_elec @title='"+e.title+"',@sdate='"+e.sdate+"',@stime='"+e.stime+"',@edate='"+e.edate+"',@etime='"+e.etime+"'", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                    return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
            finally { conn.Close(); }
        }

        /*      Register Voter      */
        public int regvoter(voterclass v)
        {
            SqlConnection conn = new SqlConnection(constring);
            try
            {
                SqlCommand cmd = new SqlCommand("exec reg_voter @fn ='" + v.fn + "',@ln = '" + v.ln + "',@govid = '" + v.govid + "',@password = '" + v.psswd + "',@reg = '" + v.region + "',@elid =" + v.elid + "", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
            finally { conn.Close(); }
        }

        /* Deactivate user account */

        public int deactivate(String id,String uty)
        {
            SqlConnection conn = new SqlConnection(constring);
            try
            {
                if (uty == "User")
                {
                    SqlCommand cmd = new SqlCommand("exec deac_usr @gov_id = '" + id + "'", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return 1;
                }else if(uty == "Candidate")
                {
                    SqlCommand cmd = new SqlCommand("exec deac_can @id = '" + id + "'", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return 1;
                }else
                    return -1;
            }
            catch (Exception ex)
            {
                return -1;
            }
            finally { conn.Close(); }
        }
        public int activate(String id, String uty)
        {
            SqlConnection conn = new SqlConnection(constring);
            try
            {
                if (uty == "User")
                {
                    SqlCommand cmd = new SqlCommand("exec ac_usr @gov_id = '" + id + "'", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return 1;
                }
                else if (uty == "Candidate")
                {
                    SqlCommand cmd = new SqlCommand("exec ac_can @id = '" + id + "'", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return 1;
                }
                else
                    return -1;
            }
            catch (Exception ex)
            {
                return -1;
            }
            finally { conn.Close(); }
        }
        public userClass infoRetus(string govid,String kind)
        {
            SqlConnection conn = new SqlConnection(constring);
            try
            {
                userClass user = new userClass();
                conn.Open();
                if (kind == "User") { 
                    SqlCommand cmd = new SqlCommand("exec deactUsrvi @gov_id = '" + govid + "'", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        user.govid = (string)reader[0];
                        user.username = (string)reader[1];
                        return user;
                    }
                    else
                        return null;
                }
                else if(kind == "Candidate")
                {
                    SqlCommand cmd = new SqlCommand("exec deactCanvi @gov_id = '" + govid + "'", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        user.govid = (string)reader[0];
                        user.username = (string)reader[1];
                        return user;
                    }
                    else
                        return null;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            finally { conn.Close(); }
        }
        public userClass infoup(string govid)
        {
            SqlConnection conn = new SqlConnection(constring);
          
                userClass user = new userClass();
                conn.Open();
                    SqlCommand cmd = new SqlCommand("exec upview @gov_id = '" + govid + "'", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        user.fname = (string)reader[0];
                        user.lname = (string)reader[1];
                        user.govid = (string)reader[2];
                        user.region = reader[3]+"";
                        user.acctype = (int)reader[4];
                        user.psswd = (string)reader[5];
                        return user;
                    }
                    else
                        return null;
            }
        public int addAdmin(Adminclass ad)
        {
            SqlConnection conn = new SqlConnection(constring);
            try
            {
                SqlCommand cmd = new SqlCommand("exec addadmin @fn = '"+ad.fname+"',@ln = '"+ad.lname+"',@gov_id = '"+ad.govid+"',@psswd = '"+ad.password+"'", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
            finally { conn.Close(); }
        }

        /* info for the voter page */

        public userClass votinfo(String govid)
        {
            SqlConnection conn = new SqlConnection(constring);
                userClass user = new userClass();
                SqlCommand cmd = new SqlCommand("exec voda @gov_id = '" + govid + "'", conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    user.fname = (string)reader[2];
                    user.lname = (string)reader[3];
                    user.govid = (string)reader[1];
                    user.region = (string)reader[4];
                    user.vstat = (int)reader[5];
                    user.elid = (int)reader[6];
                    return user;
                }
                else
                    return null;
        }
        public bool vt(String govid)
        {
            SqlConnection conn = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("exec vcheck @govid = '" + govid + "'", conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                if ((int)reader[0] == 0)
                {
                    return true;
                }
                else
                    return false;
            }
            else
            {
                return false;
            }
        }
        public vcon canloadcon(String govid)
        {
            SqlConnection conn = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("exec final @govid = '"+govid+"'", conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            vcon v = new vcon();
            if (reader.Read())
            {
               string k = (string)reader[0] + " "+ (string)reader[1];
                v.full_name = k.ToUpper();
                v.po_pa = (string)reader[2];
                v.description = (string)reader[3];
                v.img = (byte[])(reader[4]);
                return v;
            }else
                return null;
            
        }
        public int updatausr(userClass c)
        {
            SqlConnection conn = new SqlConnection(constring);
            conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("exec upuser @fn = '" + c.fname + "',@ln = '" + c.lname + "',@govid = '" + c.govid + "',@passwd='" + c.psswd + "',@region = '" + c.region + "'", conn);
                cmd.ExecuteNonQuery();
                return 1;
            }
            catch (Exception e)
            {
                return 0;
            }
            finally
            {
                conn.Close();
            }
        }

        public string lastrowsec()
        {
            SqlConnection conn = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("exec lskey", conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return ""+reader[1];
            }
            else
            {
                return null;
            }
            conn.Close();
        }
        public bool chkcode(Guid a)
        {
            SqlConnection conn = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("exec chksec @id = '"+a+"'", conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
                return true;
            else
                return false;
        }
        public int voted(Guid code, string cid,int elid,string vid)
        {

                SqlConnection conn = new SqlConnection(constring);
                SqlCommand cmd = new SqlCommand("exec inscan @scode = '" + code + "',@eid =" + elid + ",@cid ='" + cid + "'", conn);
                conn.Open();
                int x = cmd.ExecuteNonQuery();
            if (x > 0)
            {
                cmd = new SqlCommand("exec finish @govid = '" + vid + "'", conn);
                cmd.ExecuteNonQuery();
                return 1;
            }
            else
                return 0;
        }
        public int cir(string c)
        {
            SqlConnection conn = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("exec cir @cid = '"+c+"'", conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return 1;
            }else
                return 0;   
        }
        public void insr(string c,int a,string rgn)
        {
            SqlConnection conn = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("exec infr @cid = '"+c+"',@eid = "+a+",@region = '"+rgn+"'", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void uprep(string c,int n)
        {
            SqlConnection conn = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("upreport @cid = '"+c+"',@n = "+n+"", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public int numvt(string c)
        {
            SqlConnection conn = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("exec cir @cid = '" + c + "'", conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return (int)reader[3];
            }
            else
                return 0;
        }
        public string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
