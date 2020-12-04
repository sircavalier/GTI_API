using System;
using System.Collections.Generic;
using GITDAO.Commons.Providers;
using GITDAO.Entity.Cliente;
using MySql.Data.MySqlClient;

namespace GITDAO
{
    public class DAOTipoEndereco
    {
        public List<TipoEnderecoModel> GetRecord()
        {
            List<TipoEnderecoModel> objRetorno = new List<TipoEnderecoModel>();

            using (MySqlConnection conn = new MySqlConnection(ConfigurationServiceProvider.GetConnectionString("GTI.MySQL")))
            {
                conn.Open();

                using (MySqlCommand command = new MySqlCommand("Select ID, descricao from TipoEndereco", conn))
                {
                    using (MySqlDataReader mySqlData = command.ExecuteReader())
                    {
                        while (mySqlData.Read())
                        {
                            objRetorno.Add(new TipoEnderecoModel()
                            {
                                ID = (int)mySqlData["ID"],
                                Descricao = (string)mySqlData["descricao"]
                            });
                        }
                    }
                }

                return objRetorno;
            }
        }
    }
}
