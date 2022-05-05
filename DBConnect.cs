using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

class DBConnect
{
    private MySqlConnection connection;
    private string server;
    private string database;
    private string uid;
    private string password;
    private string port;

    public DBConnect()
    {
        Initialise();
    }

    private void Initialise()
    {
        server = "grandeporto.ddns.net"; // localhost or VM's IP
        database = "formandos_prog09";
        uid = "Programador09";           // root
        password = "Dados@2022";         // "" (w/o password)
        port = "3306";

        string connectionString;
        connectionString = "server=" + server + ";database=" + database +
            ";uid=" + uid + ";password=" + password + ";port=" + port + ";";
        connection = new MySqlConnection(connectionString);
    }

    private bool OpenConnection()
    {
        try
        {
            connection.Open();
            return true;
        }
        catch (MySqlException ex)
        {
            MessageBox.Show(ex.Message);
            return false;
        }
    }

    private bool CloseConnection()
    {
        try
        {
            connection.Close();
            return true;
        }
        catch (MySqlException ex)
        {
            MessageBox.Show(ex.Message);
            return false;
        }
    }

    public int Count()
    {
        string query = "Select count(*) from formando";
        int count = -1;

        if (OpenConnection())
        {
            MySqlCommand cmd = new MySqlCommand(query, connection);
            count = int.Parse(cmd.ExecuteScalar().ToString());
            CloseConnection();
        }

        return count;
    }

    public void Insert()
    {
        string query = "insert into formando values (11, 'Jorge Varandas'," +
            "'Rua Principal', null, 'PT500000001', 'M', '1970-13-11');";
        try
        {
            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
            }
        }
        catch (MySqlException ex)
        {
            MessageBox.Show(ex.Message);
        }
        finally // always does this, successful or not
        {
            CloseConnection();
        }
    }

    public bool Insert2()
    {
        string query = "insert into formando values (11, 'Jorge Varandas'," +
            "'Rua Principal', null, 'PT500000001', 'M', '1970-13-11');";
        bool flag = false;
        try
        {
            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                flag = true;
            }
        }
        catch (MySqlException ex)
        {
            MessageBox.Show(ex.Message);
        }
        finally // always does this, successful or not
        {
            CloseConnection();
        }
        return flag;
    }

    public bool Insert(string id, string name, string address, string contact, string iban, 
        char gender, string birthdate)
    {
        string query = "insert into formando (id_formando, nome, morada, contacto, iban, sexo," +
            "data_nascimento) values (" + id + ", '" + name + "', '" + address + "', '" +
            contact + "', '" + iban + "', '" + gender + "', '" + birthdate + "');";
        bool flag = false;
        try
        {
            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                flag = true;
            }
        }
        catch (MySqlException ex)
        {
            MessageBox.Show(ex.Message);
        }
        finally // always does this, successful or not
        {
            CloseConnection();
        }
        return flag;
    }

    public bool Search(string id, ref string name, ref string address, ref string contact, 
        ref string iban, ref char gender, ref string birthdate)
    {
        // string query = "select * from formando where id_formando = " + id + ";";
        string query = "select nome, morada, contacto, iban, sexo, data_nascimento " +
            "from formando where id_formando = " + id + ";";
        bool flag = false;
        try
        {
            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    name = dataReader[0].ToString(); // 0 or nome (nome as is in db)
                    address = dataReader[1].ToString();
                    contact = dataReader[2].ToString();
                    iban = dataReader[3].ToString();
                    gender = dataReader[4].ToString()[0];
                    birthdate = dataReader[5].ToString();
                    flag = true;
                }
                dataReader.Close();
            }
        }
        catch (MySqlException ex)
        {
            MessageBox.Show(ex.Message);
        }
        finally // always does this, successful or not
        {
            CloseConnection();
        }
        return flag;
    }

    public bool Update(string id, string name)
    {
        string query = "update formando set nome = '" + name + "' where id_formando = " + id + ";";
        bool flag = false;
        try
        {
            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                flag = true;
            }
        }
        catch (MySqlException ex)
        {
            MessageBox.Show(ex.Message);
        }
        finally // always does this, successful or not
        {
            CloseConnection();
        }
        return flag;
    }

    public bool Update(string id, string name, string address, string contact, string iban,
        char gender, string birthdate)
    {
        string query = "update formando set nome = '" + name + "', morada = '" + address + 
            "', contacto = '" + contact + "', iban = '" + iban + "', sexo = '" + gender + 
            "', data_nascimento = '" + birthdate + "' where id_formando = " + id + ";";
        bool flag = false;
        try
        {
            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                flag = true;
            }
        }
        catch (MySqlException ex)
        {
            MessageBox.Show(ex.Message);
        }
        finally // always does this, successful or not
        {
            CloseConnection();
        }
        return flag;
    }

    public bool Delete(string id)
    {
        string query = "delete from formando where id_formando = " + id + ";";
        bool flag = false;
        try
        {
            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                flag = true;
            }
        }
        catch (MySqlException ex)
        {
            MessageBox.Show(ex.Message);
        }
        finally // always does this, successful or not
        {
            CloseConnection();
        }
        return flag;
    }

    public int MaxID()
    {
        string query = "select max(id_formando) from formando;";
        int maxID = 0;

        try
        {
            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                // maxID = int.Parse(cmd.ExecuteScalar().ToString());
                // maxID++;
                int.TryParse(cmd.ExecuteScalar().ToString(), out maxID);
                CloseConnection();
            }
        } 
        catch (MySqlException ex)
        {
            MessageBox.Show(ex.Message);
        }

        return maxID;
    }

    public void FillTraineeDataGridFilter(ref DataGridView dgv, string name, char gender)
    {
        string query = "select id_formando, nome, iban, data_nascimento, sexo from formando";
        bool flag = false;

        if (gender != 'T' && gender != ' ')
        {
            query = query + " where sexo = '" + gender + "';";
            flag = true;
        }

        if (name.Length > 0)
        {
            if (flag)
            {
                query = query + " and nome like '%" + name + "%';";
            }
            else
            {
                query = query + " where nome like '%" + name + "%';";
            }
            
        }

        try
        {
            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dr = cmd.ExecuteReader();

                int idxLine = 0;
                while (dr.Read())
                {
                    dgv.Rows.Add();
                    dgv.Rows[idxLine].Cells[0].Value = dr[0].ToString();
                    dgv.Rows[idxLine].Cells[1].Value = dr[1].ToString();
                    dgv.Rows[idxLine].Cells[2].Value = dr[2].ToString();
                    dgv.Rows[idxLine].Cells[3].Value = DateTime.Parse(dr[3].ToString()).ToString("dd-MM-yyyy");
                    dgv.Rows[idxLine].Cells[4].Value = dr[4].ToString();
                    idxLine++;
                }
            }
        }
        catch (MySqlException ex)
        {
            MessageBox.Show(ex.Message);
        }
        finally
        {
            CloseConnection();
        }
    }
}