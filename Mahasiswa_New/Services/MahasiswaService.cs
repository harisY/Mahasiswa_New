using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Mahasiswa_New.Helpers;
using Mahasiswa_New.Models;

namespace Mahasiswa_New.Services
{
    public class MahasiswaService
    {

        public List<MahasiswaModel> GetListMahasiswa()
        {
            try
            {
                List<MahasiswaModel> Result = new List<MahasiswaModel>();
                string Query = @"SELECT 
                                    m.NPM,
                                    m.Nama,
                                    m.JK,
                                    j.Jurusan,
                                    m.Alamat,
                                    Convert(varchar,m.TglLahir,101) TglLahir,
                                    m.Email 
                                FROM TbMahasiswa m LEFT JOIN
                                TbJurusan j on m.IdJurusan = j.IdJurusan";
                DataTable dt = new DataTable();
                dt = SQLHelpers.GetDataTable(Query);

                foreach (DataRow dr in dt.Rows)
                {
                    Result.Add(
                        new MahasiswaModel
                        {
                            NPM = Convert.ToString(dr["NPM"]),
                            Nama = Convert.ToString(dr["Nama"]),
                            JK = Convert.ToString(dr["JK"]),
                            Jurusan = Convert.ToString(dr["Jurusan"]),
                            Alamat = Convert.ToString(dr["Alamat"]),
                            TglLahir = Convert.ToString(dr["TglLahir"]),
                            Email = Convert.ToString(dr["Email"])
                        });
                }
                return Result;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<MahasiswaModel> GetListMahasiswaById(string id)
        {
            try
            {
                List<MahasiswaModel> Result = new List<MahasiswaModel>();
                string Query = @"SELECT convert(varchar,TglLahir,101) tgl,  * FROM TbMahasiswa where NPM = '" + id + "'";
                DataTable dt = new DataTable();
                dt = SQLHelpers.GetDataTable(Query);
                foreach (DataRow dr in dt.Rows)
                {
                    Result.Add(
                        new MahasiswaModel
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            NPM = Convert.ToString(dr["NPM"]),
                            Nama = Convert.ToString(dr["Nama"]),
                            JK = Convert.ToString(dr["JK"]),
                            IdJurusan = Convert.ToString(dr["IdJurusan"]),
                            Alamat = Convert.ToString(dr["Alamat"]),
                            TglLahir = Convert.ToString(dr["tgl"]),
                            Email = Convert.ToString(dr["Email"])

                        });
                }
                return Result;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public int SimpanMahasiswa(MahasiswaModel model)
        {
            int hasil = -1;
            try
            {
                string Query = @"Insert into TbMahasiswa ([NPM]
                                    ,[Nama]
                                    ,[JK]
                                    ,[IdJurusan]
                                    ,[Alamat]
                                    ,[TglLahir]
                                    ,[Email])
                                Values('" + model.NPM + "'," +
                                        "'" + model.Nama + "'," +
                                        "'" + model.JK + "'," +
                                        "'" + model.IdJurusan + "'," +
                                        "'" + model.Alamat + "'," +
                                        "'" + model.TglLahir + "'," +
                                        "'" + model.Email + "')";
                hasil = SQLHelpers.ExecQuery(Query);
                return hasil;
            }

            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int UpdateMahasiswa(MahasiswaModel model)
        {
            int hasil = -1;
            try
            {
                string Query = @"Update TbMahasiswa 
                                SET Nama        = '" + model.Nama + "', " +
                                    "JK         = '" + model.JK + "', " +
                                    "IdJurusan  = '" + model.IdJurusan + "', " +
                                    "Alamat     = '" + model.Alamat + "', " +
                                    "TglLahir   = '" + model.TglLahir + "', " +
                                    "Email      = '" + model.Email + "' " +
                                "Where NPM      = '" + model.NPM + "'";
                hasil = SQLHelpers.ExecQuery(Query);
                return hasil;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int DeleteMahasiswa(string NPM)
        {
            int hasil = -1;
            try
            {
                string Query = @"Delete TbMahasiswa Where IdMahasiswa = '" + NPM + "'";
                hasil = SQLHelpers.ExecQuery(Query);
                return hasil;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool IsDataExist(string NPM)
        {
            bool hasil = false;
            try
            {
                string Query = @"select * from TbMahasiswa where NPM = '" + NPM + "'";
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

        public List<StandartComboBox> GetJurusan()
        {
            List<StandartComboBox> Result = new List<StandartComboBox>();
            string Query = @"SELECT IdJurusan, Jurusan From TbJurusan";
            DataTable dt = new DataTable();
            dt = SQLHelpers.GetDataTable(Query);

            foreach (DataRow dr in dt.Rows)
            {
                Result.Add(
                    new StandartComboBox
                    {
                        Value = Convert.ToString(dr["IdJurusan"]),
                        Text = Convert.ToString(dr["Jurusan"])
                    });
            }
            return Result;
        }
    }
}