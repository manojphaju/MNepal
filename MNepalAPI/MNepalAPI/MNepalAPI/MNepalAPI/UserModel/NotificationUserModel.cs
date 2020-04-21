﻿using MNepalAPI.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using static MNepalAPI.Models.Notifications;

namespace MNepalAPI.UserModel
{
    public class NotificationUserModel
    {
        #region notifications
        public int ResponseNotificationInfo(NotificationModel objresNotificationInfo)
        {
            SqlConnection sqlCon = null;
            int ret;
            try
            {
                using (sqlCon = new SqlConnection(DatabaseConnection.ConnectionString()))
                {
                    sqlCon.Open();
                    using (SqlCommand sqlCmd = new SqlCommand("[s_MNNotifications]", sqlCon))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        sqlCmd.Parameters.AddWithValue("@extraInformation", objresNotificationInfo.extraInformation);
                        sqlCmd.Parameters.AddWithValue("@title", objresNotificationInfo.title);
                        sqlCmd.Parameters.AddWithValue("@text", objresNotificationInfo.text);
                        sqlCmd.Parameters.AddWithValue("@messageId", objresNotificationInfo.messageId);
                        ret = sqlCmd.ExecuteNonQuery();
                        //if (objresPaypointPaymentInfo.Mode.Equals("SCA", StringComparison.InvariantCultureIgnoreCase))
                        //{
                        //    ret = Convert.ToInt32(sqlCmd.Parameters["@RegIDOut"].Value);

                        //}
                    }

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (sqlCon != null)
                {
                    sqlCon.Close();
                }
            }
            return ret;
        }

        #endregion
    }
}