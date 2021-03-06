﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace OSUBeatmapTool.Lib
{
    /// <summary>  
    /// 本类为SQLite数据库帮助类  
    /// 轻量级数据库SQLite的连接字符串写法："Data Source=D:\database\test.s3db"  
    /// 轻量级数据库SQLite的加密后的连接字符串写法："Data Source=Maximus.db;Version=3;Password=myPassword;"  
    /// </summary>  
    public class SqliteHelper
    {
        //数据库连接字符串  
        private readonly string _conn = string.Empty;

        public SqliteHelper(string connectionString)
        {
            _conn = connectionString;
        }

        public bool CreatDB()
        {
            try
            {
                string strSql = "CREATE TABLE [tblHistoryMessage] ([RecID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, [ConversationID] nvarchar(100), [FromUri] nvarchar(50), [ToUri] nvarchar(50), [SendDT] datetime, [MessageText] text, [FromUriName] nvarchar(50), [ToUriName] nvarchar(50));";
                ExecuteNonQuery(strSql, CommandType.Text);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        #region ExecuteNonQuery
        /// <summary>  
        /// 执行数据库操作(新增、更新或删除)  
        /// </summary>  
        /// <param name="connectionString">连接字符串</param>  
        /// <param name="cmd">SqlCommand对象</param>  
        /// <returns>所受影响的行数</returns>  
        public int ExecuteNonQuery(SQLiteCommand cmd)
        {
            int result = 0;
            if (string.IsNullOrEmpty(_conn))
                throw new ArgumentNullException("Connection string is missing.");
            using (SQLiteConnection con = new SQLiteConnection(_conn))
            {
                SQLiteTransaction trans = null;
                PrepareCommand(cmd, con, ref trans, true, cmd.CommandType, cmd.CommandText);
                try
                {
                    result = cmd.ExecuteNonQuery();
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw ex;
                }
            }
            return result;
        }

        /// <summary>  
        /// 执行数据库操作(新增、更新或删除)  
        /// </summary>  
        /// <param name="connectionString">连接字符串</param>  
        /// <param name="commandText">执行语句或存储过程名</param>  
        /// <param name="commandType">执行类型</param>  
        /// <returns>所受影响的行数</returns>  
        public int ExecuteNonQuery(string commandText, CommandType commandType)
        {
            int result = 0;
            if (string.IsNullOrEmpty(_conn))
                throw new ArgumentNullException("Connection string is missing.");
            if (string.IsNullOrEmpty(commandText))
                throw new ArgumentNullException("commandText");
            SQLiteCommand cmd = new SQLiteCommand();
            using (SQLiteConnection con = new SQLiteConnection(_conn))
            {
                SQLiteTransaction trans = null;
                PrepareCommand(cmd, con, ref trans, true, commandType, commandText);
                try
                {
                    result = cmd.ExecuteNonQuery();
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw ex;
                }
            }
            return result;
        }

        /// <summary>  
        /// 执行数据库操作(新增、更新或删除)  
        /// </summary>  
        /// <param name="connectionString">连接字符串</param>  
        /// <param name="commandText">执行语句或存储过程名</param>  
        /// <param name="commandType">执行类型</param>  
        /// <param name="cmdParms">SQL参数对象</param>  
        /// <returns>所受影响的行数</returns>  
        public int ExecuteNonQuery(string commandText, CommandType commandType, params SQLiteParameter[] cmdParms)
        {
            int result = 0;
            if (string.IsNullOrEmpty(_conn))
                throw new ArgumentNullException("Connection string is missing.");
            if (string.IsNullOrEmpty(commandText))
                throw new ArgumentNullException("commandText");

            SQLiteCommand cmd = new SQLiteCommand();
            using (SQLiteConnection con = new SQLiteConnection(_conn))
            {
                SQLiteTransaction trans = null;
                PrepareCommand(cmd, con, ref trans, true, commandType, commandText, cmdParms);
                try
                {
                    result = cmd.ExecuteNonQuery();
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw ex;
                }
            }
            return result;
        }
        #endregion

        #region ExecuteScalar
        /// <summary>  
        /// 执行数据库操作(新增、更新或删除)同时返回执行后查询所得的第1行第1列数据  
        /// </summary>  
        /// <param name="connectionString">连接字符串</param>  
        /// <param name="cmd">SqlCommand对象</param>  
        /// <returns>查询所得的第1行第1列数据</returns>  
        public object ExecuteScalar(SQLiteCommand cmd)
        {
            object result = 0;
            if (string.IsNullOrEmpty(_conn))
                throw new ArgumentNullException("Connection string is missing.");
            using (SQLiteConnection con = new SQLiteConnection(_conn))
            {
                SQLiteTransaction trans = null;
                PrepareCommand(cmd, con, ref trans, true, cmd.CommandType, cmd.CommandText);
                try
                {
                    result = cmd.ExecuteScalar();
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw ex;
                }
            }
            return result;
        }

        /// <summary>  
        /// 执行数据库操作(新增、更新或删除)同时返回执行后查询所得的第1行第1列数据  
        /// </summary>  
        /// <param name="connectionString">连接字符串</param>  
        /// <param name="commandText">执行语句或存储过程名</param>  
        /// <param name="commandType">执行类型</param>  
        /// <returns>查询所得的第1行第1列数据</returns>  
        public object ExecuteScalar(string commandText, CommandType commandType)
        {
            object result = 0;
            if (string.IsNullOrEmpty(_conn))
                throw new ArgumentNullException("Connection string is missing.");
            if (string.IsNullOrEmpty(commandText))
                throw new ArgumentNullException("commandText");
            SQLiteCommand cmd = new SQLiteCommand();
            using (SQLiteConnection con = new SQLiteConnection(_conn))
            {
                SQLiteTransaction trans = null;
                PrepareCommand(cmd, con, ref trans, true, commandType, commandText);
                try
                {
                    result = cmd.ExecuteScalar();
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw ex;
                }
            }
            return result;
        }

        /// <summary>  
        /// 执行数据库操作(新增、更新或删除)同时返回执行后查询所得的第1行第1列数据  
        /// </summary>  
        /// <param name="connectionString">连接字符串</param>  
        /// <param name="commandText">执行语句或存储过程名</param>  
        /// <param name="commandType">执行类型</param>  
        /// <param name="cmdParms">SQL参数对象</param>  
        /// <returns>查询所得的第1行第1列数据</returns>  
        public object ExecuteScalar(string commandText, CommandType commandType, params SQLiteParameter[] cmdParms)
        {
            object result = 0;
            if (string.IsNullOrEmpty(_conn))
                throw new ArgumentNullException("Connection string is missing.");
            if (string.IsNullOrEmpty(commandText))
                throw new ArgumentNullException("commandText");

            SQLiteCommand cmd = new SQLiteCommand();
            using (SQLiteConnection con = new SQLiteConnection(_conn))
            {
                SQLiteTransaction trans = null;
                PrepareCommand(cmd, con, ref trans, true, commandType, commandText);
                try
                {
                    result = cmd.ExecuteScalar();
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw ex;
                }
            }
            return result;
        }
        #endregion

        #region ExecuteReader
        /// <summary>  
        /// 执行数据库查询，返回SqlDataReader对象  
        /// </summary>  
        /// <param name="connectionString">连接字符串</param>  
        /// <param name="cmd">SqlCommand对象</param>  
        /// <returns>SqlDataReader对象</returns>  
        public DbDataReader ExecuteReader(SQLiteCommand cmd)
        {
            DbDataReader reader = null;
            if (string.IsNullOrEmpty(_conn))
                throw new ArgumentNullException("Connection string is missing.");

            SQLiteConnection con = new SQLiteConnection(_conn);
            SQLiteTransaction trans = null;
            PrepareCommand(cmd, con, ref trans, false, cmd.CommandType, cmd.CommandText);
            try
            {
                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return reader;
        }

        /// <summary>  
        /// 执行数据库查询，返回SqlDataReader对象  
        /// </summary>  
        /// <param name="connectionString">连接字符串</param>  
        /// <param name="commandText">执行语句或存储过程名</param>  
        /// <param name="commandType">执行类型</param>  
        /// <returns>SqlDataReader对象</returns>  
        public DbDataReader ExecuteReader(string commandText, CommandType commandType)
        {
            DbDataReader reader = null;
            if (string.IsNullOrEmpty(_conn))
                throw new ArgumentNullException("Connection string is missing.");
            if (string.IsNullOrEmpty(commandText))
                throw new ArgumentNullException("commandText");

            SQLiteConnection con = new SQLiteConnection(_conn);
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteTransaction trans = null;
            PrepareCommand(cmd, con, ref trans, false, commandType, commandText);
            try
            {
                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return reader;
        }

        /// <summary>  
        /// 执行数据库查询，返回SqlDataReader对象  
        /// </summary>  
        /// <param name="connectionString">连接字符串</param>  
        /// <param name="commandText">执行语句或存储过程名</param>  
        /// <param name="commandType">执行类型</param>  
        /// <param name="cmdParms">SQL参数对象</param>  
        /// <returns>SqlDataReader对象</returns>  
        public DbDataReader ExecuteReader(string commandText, CommandType commandType, params SQLiteParameter[] cmdParms)
        {
            DbDataReader reader = null;
            if (string.IsNullOrEmpty(_conn))
                throw new ArgumentNullException("Connection string is missing.");
            if (string.IsNullOrEmpty(commandText))
                throw new ArgumentNullException("commandText");

            SQLiteConnection con = new SQLiteConnection(_conn);
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteTransaction trans = null;
            PrepareCommand(cmd, con, ref trans, false, commandType, commandText, cmdParms);
            try
            {
                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return reader;
        }
        #endregion

        #region ExecuteDataSet
        /// <summary>  
        /// 执行数据库查询，返回DataSet对象  
        /// </summary>  
        /// <param name="connectionString">连接字符串</param>  
        /// <param name="cmd">SqlCommand对象</param>  
        /// <returns>DataSet对象</returns>  
        public DataSet ExecuteDataSet(SQLiteCommand cmd)
        {
            DataSet ds = new DataSet();
            SQLiteConnection con = new SQLiteConnection(_conn);
            SQLiteTransaction trans = null;
            PrepareCommand(cmd, con, ref trans, false, cmd.CommandType, cmd.CommandText);
            try
            {
                SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd);
                sda.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cmd.Connection != null)
                {
                    if (cmd.Connection.State == ConnectionState.Open)
                    {
                        cmd.Connection.Close();
                    }
                }
            }
            return ds;
        }

        /// <summary>  
        /// 执行数据库查询，返回DataSet对象  
        /// </summary>  
        /// <param name="connectionString">连接字符串</param>  
        /// <param name="commandText">执行语句或存储过程名</param>  
        /// <param name="commandType">执行类型</param>  
        /// <returns>DataSet对象</returns>  
        public DataSet ExecuteDataSet(string commandText, CommandType commandType)
        {
            if (string.IsNullOrEmpty(_conn))
                throw new ArgumentNullException("Connection string is missing.");
            if (string.IsNullOrEmpty(commandText))
                throw new ArgumentNullException("commandText");
            DataSet ds = new DataSet();
            SQLiteConnection con = new SQLiteConnection(_conn);
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteTransaction trans = null;
            PrepareCommand(cmd, con, ref trans, false, commandType, commandText);
            try
            {
                SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd);
                sda.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
            return ds;
        }

        /// <summary>  
        /// 执行数据库查询，返回DataSet对象  
        /// </summary>  
        /// <param name="connectionString">连接字符串</param>  
        /// <param name="commandText">执行语句或存储过程名</param>  
        /// <param name="commandType">执行类型</param>  
        /// <param name="cmdParms">SQL参数对象</param>  
        /// <returns>DataSet对象</returns>  
        public DataSet ExecuteDataSet(string commandText, CommandType commandType, params SQLiteParameter[] cmdParms)
        {
            if (string.IsNullOrEmpty(_conn))
                throw new ArgumentNullException("Connection string is missing.");
            if (string.IsNullOrEmpty(commandText))
                throw new ArgumentNullException("commandText");
            DataSet ds = new DataSet();
            SQLiteConnection con = null;
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteTransaction trans = null;
            try
            {
                con = new SQLiteConnection(_conn);
                PrepareCommand(cmd, con, ref trans, false, commandType, commandText, cmdParms);
                SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd);
                sda.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
            return ds;
        }
        #endregion

        /// <summary>  
        /// 通用分页查询方法  
        /// </summary>  
        /// <param name="connString">连接字符串</param>  
        /// <param name="tableName">表名</param>  
        /// <param name="strColumns">查询字段名</param>  
        /// <param name="strWhere">where条件</param>  
        /// <param name="strOrder">排序条件</param>  
        /// <param name="pageSize">每页数据数量</param>  
        /// <param name="currentIndex">当前页数</param>  
        /// <param name="recordOut">数据总量</param>  
        /// <returns>DataTable数据表</returns>  
        public DataTable SelectPaging(string tableName, string strColumns, string strWhere, string strOrder, int pageSize, int currentIndex, out int recordOut)
        {
            DataTable dt = new DataTable();
            //查询总数  
            string countSql = "select count(*) from " + tableName + " where {0}";
            countSql = String.Format(countSql, strWhere);
            Log.WriteLog(LogFile.SQL,countSql);
            recordOut = Convert.ToInt32(ExecuteScalar(countSql, CommandType.Text));
            //分页  
            string pagingTemplate = "select {0} from {1} where {2} order by {3} limit {4} offset {5} ";
            int offsetCount = (currentIndex - 1) * pageSize;
            string commandText = String.Format(pagingTemplate, strColumns, tableName, strWhere, strOrder, pageSize.ToString(), offsetCount.ToString());
            using (DbDataReader reader = ExecuteReader(commandText, CommandType.Text))
            {
                if (reader != null)
                {
                    dt.Load(reader);
                }
            }
            return dt;
        }

        /// <summary>  
        /// 预处理Command对象,数据库链接,事务,需要执行的对象,参数等的初始化  
        /// </summary>  
        /// <param name="cmd">Command对象</param>  
        /// <param name="conn">Connection对象</param>  
        /// <param name="trans">Transcation对象</param>  
        /// <param name="useTrans">是否使用事务</param>  
        /// <param name="cmdType">SQL字符串执行类型</param>  
        /// <param name="cmdText">SQL Text</param>  
        /// <param name="cmdParms">SQLiteParameters to use in the command</param>  
        private void PrepareCommand(SQLiteCommand cmd, SQLiteConnection conn, ref SQLiteTransaction trans, bool useTrans, CommandType cmdType, string cmdText, params SQLiteParameter[] cmdParms)
        {

            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = cmdText;

            if (useTrans)
            {
                trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                cmd.Transaction = trans;
            }


            cmd.CommandType = cmdType;

            if (cmdParms != null)
            {
                foreach (SQLiteParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }
    }  
}
