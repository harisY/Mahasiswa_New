using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Mahasiswa_New.Helpers;
using Mahasiswa_New.Models;

namespace Mahasiswa_New.Services
{
    public class JurusanService
    {

        public List<JurusanModel> GetListJurusan()
        {
            try
            {
                List<JurusanModel> Result = new List<JurusanModel>();
                string Query = @"SELECT * FROM TbJurusan";
                DataTable dt = new DataTable();
                dt = SQLHelpers.GetDataTable(Query);

                foreach (DataRow dr in dt.Rows)
                {
                    Result.Add(
                        new JurusanModel
                        {
                            idJurusan = Convert.ToString(dr["IdJurusan"]),
                            jurusan = Convert.ToString(dr["Jurusan"])

                        });
                }
                return Result;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<JurusanModel> GetListJurusanById(string id)
        {
            try
            {
                List<JurusanModel> Result = new List<JurusanModel>();
                string Query = @"SELECT * FROM TbJurusan where IdJurusan = '" + id + "'";
                DataTable dt = new DataTable();
                dt = SQLHelpers.GetDataTable(Query);
                foreach (DataRow dr in dt.Rows)
                {
                    Result.Add(
                        new JurusanModel
                        {
                            idJurusan = Convert.ToString(dr["IdJurusan"]),
                            jurusan = Convert.ToString(dr["Jurusan"])

                        });
                }
                return Result;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public int SimpanJurusan(JurusanModel model)
        {
            int hasil = -1;
            try
            {
                string Query = @"Insert into TbJurusan Values('" + model.idJurusan + "','" + model.jurusan + "')";
                hasil = SQLHelpers.ExecQuery(Query);
                return hasil;
            }

            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int UpdateJurusan(JurusanModel model)
        {
            int hasil = -1;
            try
            {
                string Query = @"Update TbJurusan 
                                set Jurusan = '" + model.jurusan + "' " +
                                "Where IdJurusan = '" + model.idJurusan + "'";
                hasil = SQLHelpers.ExecQuery(Query);
                return hasil;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int DeleteJurusan(string Id)
        {
            int hasil = -1;
            try
            {
                string Query = @"Delete TbJurusan Where IdJurusan = '" + Id + "'";
                hasil = SQLHelpers.ExecQuery(Query);
                return hasil;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool IsDataExist(string Id)
        {
            bool hasil = false;
            try
            {
                string Query = @"select * from TbJurusan where IdJurusan = '" + Id + "'";
                DataTable dt = new DataTable();
                dt = SQLHelpers.GetDataTable(Query);
                if (dt.Rows.Count > 0)
                {
                    hasil = true;
                }
                return hasil;
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}