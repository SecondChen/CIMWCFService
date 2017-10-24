using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.IO;
using System.Xml;


namespace CIMWCFService
{
    // 注意: 您可以使用 [重構] 功能表上的 [重新命名] 命令同時變更程式碼、svc 和組態檔中的類別名稱 "Service1"。
    // 注意: 若要啟動 WCF 測試用戶端以便測試此服務，請在 [方案總管] 中選取 Service1.svc 或 Service1.svc.cs，然後開始偵錯。
    public class Service1 : IService1
    {
        #region 相關欄位參數
        /// <summary>
        /// 相關欄位參數
        PublicWebService.WebService pb_ws = new PublicWebService.WebService();
        static String sEnvironment = GetEnvironment();
        /// </summary>
        [Serializable]
        //AOI量測資料 資料結構
        public class AOIInfo
        {
            [System.Xml.Serialization.XmlElement("FAB")]
            public string FAB;
            [System.Xml.Serialization.XmlElement("LINE")]
            public string LINE;
            [System.Xml.Serialization.XmlElement("STATION")]
            public string STATION;
            [System.Xml.Serialization.XmlElement("DEVICE_TYPE")]
            public string DEVICE_TYPE;
            [System.Xml.Serialization.XmlElement("MODEL_NAME")]
            public string MODEL_NAME;
            [System.Xml.Serialization.XmlElement("SHIFT_ID")]
            public string SHIFT_ID;
            [System.Xml.Serialization.XmlElement("WO")]
            public string WO;



            [System.Xml.Serialization.XmlElement("TRX_NAME")]
            public string TRX_NAME;
            [System.Xml.Serialization.XmlElement("TYPE_ID")]
            public string TYPE_ID;
            [System.Xml.Serialization.XmlElement("LOG_ID")]
            public string LOG_ID;
            [System.Xml.Serialization.XmlElement("DEVICE_ID")]
            public string DEVICE_ID;
            [System.Xml.Serialization.XmlElement("USER_ID")]
            public string USER_ID;
            [System.Xml.Serialization.XmlElement("BARCODE_ID")]
            public string BARCODE_ID;
            [System.Xml.Serialization.XmlElement("TEST_TIME")]
            public string TEST_TIME;
            [System.Xml.Serialization.XmlElement("TEST_RESULT")] 
            public string TEST_RESULT;
            [System.Xml.Serialization.XmlElement("DEFECT_CNT")]
            public string DEFECT_CNT;
            [System.Xml.Serialization.XmlElement("O_SIZE_COUNT")]//10
            public string O_SIZE_COUNT;

            [System.Xml.Serialization.XmlElement("L_SIZE_COUNT")]
            public string L_SIZE_COUNT;
            [System.Xml.Serialization.XmlElement("M_SIZE_COUNT")] 
            public string M_SIZE_COUNT;
            [System.Xml.Serialization.XmlElement("S_SIZE_COUNT")]
            public string S_SIZE_COUNT;
            [System.Xml.Serialization.XmlElement("TEST_PROGRAM")]
            public string TEST_PROGRAM;
            [System.Xml.Serialization.XmlElement("CENTERLV")]
            public string CENTERLV;
            [System.Xml.Serialization.XmlElement("IMAGE_FILE_PATH")] 
            public string IMAGE_FILE_PATH;
            [System.Xml.Serialization.XmlElement("CCD_NO")]   
            public string CCD_NO;

            [System.Xml.Serialization.XmlElement("DEFECT_INFO")]
            public AOIDefectInfo[] DefectLineInfo;

            [System.Xml.Serialization.XmlElement("RTN_CODE")]   
            public string RTN_CODE;
            [System.Xml.Serialization.XmlElement("RTN_MSG")]   //20
            public string RTN_MSG;

 
        }

        [Serializable]
        //AOI重複性DEFECT資料 資料結構
        public class AOIDefectInfo
        {
            [System.Xml.Serialization.XmlElement("DEFECT_CODE")]
            public string DEFECT_CODE;
            [System.Xml.Serialization.XmlElement("DEFECT_DESC")]
            public string DEFECT_DESC;
            [System.Xml.Serialization.XmlElement("DEFECT_VALUE")]
            public string DEFECT_VALUE;
            [System.Xml.Serialization.XmlElement("DEFECT_NUM")]
            public string DEFECT_NUM;
            [System.Xml.Serialization.XmlElement("DEFECT_LOCATION_X")]
            public string DEFECT_LOCATION_X;
            [System.Xml.Serialization.XmlElement("DEFECT_LOCATION_Y")]
            public string DEFECT_LOCATION_Y;
            [System.Xml.Serialization.XmlElement("REVIEW")]
            public string REVIEW;
            [System.Xml.Serialization.XmlElement("DATA_NO")]
            public string DATA_NO;
            [System.Xml.Serialization.XmlElement("GATE_NO")]
            public string GATE_NO;
            [System.Xml.Serialization.XmlElement("FLAG")]
            public string FLAG;
            [System.Xml.Serialization.XmlElement("DEFECT_REAL_SIZE")]
            public string DEFECT_REAL_SIZE;
            [System.Xml.Serialization.XmlElement("DEFECT_REAL_X_SIZE")]
            public string DEFECT_REAL_X_SIZE;
            [System.Xml.Serialization.XmlElement("DEFECT_REAL_Y_SIZE")]
            public string DEFECT_REAL_Y_SIZE;
            [System.Xml.Serialization.XmlElement("DEFECT_GRAY_LEVEL")]
            public string DEFECT_GRAY_LEVEL;
            [System.Xml.Serialization.XmlElement("ZONE")]
            public string ZONE;
            [System.Xml.Serialization.XmlElement("PI_NO")]
            public string PI_NO;
            [System.Xml.Serialization.XmlElement("PANEL_ID")]
            public string PANEL_ID;
        }


        //尺寸機參數資料 資料結構
        public class MicroScopeInfo
        {
            [System.Xml.Serialization.XmlElement("FAB")]
            public string FAB;
            [System.Xml.Serialization.XmlElement("LINE")]
            public string LINE;
            [System.Xml.Serialization.XmlElement("STATION")]
            public string STATION;
            [System.Xml.Serialization.XmlElement("DEVICE_TYPE")]
            public string DEVICE_TYPE;
            [System.Xml.Serialization.XmlElement("MODEL_NAME")]
            public string MODEL_NAME;
            [System.Xml.Serialization.XmlElement("SHIFT_ID")]
            public string SHIFT_ID;
            [System.Xml.Serialization.XmlElement("WO")]
            public string WO;

            [System.Xml.Serialization.XmlElement("TRX_NAME")]
            public string TRX_NAME;
            [System.Xml.Serialization.XmlElement("TYPE_ID")]
            public string TYPE_ID;
            [System.Xml.Serialization.XmlElement("LOG_ID")]
            public string LOG_ID;
            [System.Xml.Serialization.XmlElement("DEVICE_ID")]
            public string DEVICE_ID;
            [System.Xml.Serialization.XmlElement("USER_ID")]
            public string USER_ID;
            [System.Xml.Serialization.XmlElement("BARCODE_ID")]
            public string BARCODE_ID;
            [System.Xml.Serialization.XmlElement("TEST_TIME")]
            public string TEST_TIME;
            [System.Xml.Serialization.XmlElement("TEST_RECIPE_NAME")]  //8
            public string TEST_RECIPE_NAME;


            [System.Xml.Serialization.XmlElement("DEFECT_INFO")]
            public MSMeasureInfo[] MSLineInfo;

            [System.Xml.Serialization.XmlElement("RTN_CODE")]
            public string RTN_CODE;
            [System.Xml.Serialization.XmlElement("RTN_MSG")]   //20
            public string RTN_MSG;
        }

        [Serializable]
        //尺寸機重複性量測資料 資料結構
        public class MSMeasureInfo
        {
            [System.Xml.Serialization.XmlElement("FIG_NAME")]
            public string FIG_NAME;
            [System.Xml.Serialization.XmlElement("COORDINATE_CODE")]
            public string COORDINATE_CODE;
            [System.Xml.Serialization.XmlElement("COORDINATE_X")]
            public string COORDINATE_X;
            [System.Xml.Serialization.XmlElement("COORDINATE_Y")]
            public string COORDINATE_Y;
            [System.Xml.Serialization.XmlElement("COORDINATE_R")]
            public string COORDINATE_R;
            [System.Xml.Serialization.XmlElement("COORDINATE_T")]
            public string COORDINATE_T;
            [System.Xml.Serialization.XmlElement("COORDINATE_Z")]
            public string COORDINATE_Z;
            [System.Xml.Serialization.XmlElement("CONE_ANGLE")]
            public string CONE_ANGLE;
            [System.Xml.Serialization.XmlElement("RADIUS")]  
            public string RADIUS;
            [System.Xml.Serialization.XmlElement("DIAMETER")]  //10
            public string DIAMETER;
            [System.Xml.Serialization.XmlElement("FLATNESS")]
            public string FLATNESS;

            [System.Xml.Serialization.XmlElement("PERIMETER")]
            public string PERIMETER;
            [System.Xml.Serialization.XmlElement("SPINDLE_X_LENGTH")]
            public string SPINDLE_X_LENGTH;
            [System.Xml.Serialization.XmlElement("SPINDLE_Y_LENGTH")]
            public string SPINDLE_Y_LENGTH;
            [System.Xml.Serialization.XmlElement("SPINDLE_Z_LENGTH")]
            public string SPINDLE_Z_LENGTH;
            [System.Xml.Serialization.XmlElement("AREA")]
            public string AREA;
            [System.Xml.Serialization.XmlElement("STARTING_ANGLE")]
            public string STARTING_ANGLE;
            [System.Xml.Serialization.XmlElement("TERMINATION_ANGLE")]
            public string TERMINATION_ANGLE;
            [System.Xml.Serialization.XmlElement("PROJECTION_DISTANCE_XY")]
            public string PROJECTION_DISTANCE_XY;
            [System.Xml.Serialization.XmlElement("PROJECTION_DISTANCE_YZ")]
            public string PROJECTION_DISTANCE_YZ;
            [System.Xml.Serialization.XmlElement("PROJECTION_DISTANCE_XZ")]
            public string PROJECTION_DISTANCE_XZ;
            [System.Xml.Serialization.XmlElement("INNER_DIAMETER")]
            public string INNER_DIAMETER;
            [System.Xml.Serialization.XmlElement("OUTER_DIAMETER")]
            public string OUTER_DIAMETER;
            [System.Xml.Serialization.XmlElement("INNER_CIRCUMFERENCE")]
            public string INNER_CIRCUMFERENCE;
            [System.Xml.Serialization.XmlElement("OUTER_CIRCUMFERENCE")]
            public string OUTER_CIRCUMFERENCE;
            [System.Xml.Serialization.XmlElement("AVG_THICKNESS")]
            public string AVG_THICKNESS;
            [System.Xml.Serialization.XmlElement("ELEVATION_ANGLE")]
            public string ELEVATION_ANGLE;
            [System.Xml.Serialization.XmlElement("MEASUREMENT_TIME")]
            public string MEASUREMENT_TIME;
        }

        [Serializable]
        //回傳廠商處理訊息資料結構
        public class Message
        {
            [System.Xml.Serialization.XmlElement("TRX_NAME")]
            public string TRX_NAME;
            [System.Xml.Serialization.XmlElement("TYPE_ID")]
            public string TYPE_ID;
            [System.Xml.Serialization.XmlElement("LOG_ID")]
            public string LOG_ID;
            [System.Xml.Serialization.XmlElement("BARCODE_ID")]
            public string BARCODE_ID;
            [System.Xml.Serialization.XmlElement("RTN_CODE")]
            public string RTN_CODE;
            [System.Xml.Serialization.XmlElement("RTN_MSG")]
            public string RTN_MSG;
            [System.Xml.Serialization.XmlElement("RTN_CODE_MSG")]  //7
            public string RTN_CODE_MSG;

        }
        #endregion




        public string InsertAOIProcessData(string sXML)
        {
            Message message = new Message();
            AOIInfo aoiInfo = new AOIInfo();
            //Sample XML
            sXML = "<TRX><TRX_NAME>InsertAOIProcessData</TRX_NAME><TYPE_ID>IN</TYPE_ID><LOG_ID>17050803.07.11_20170829173900</LOG_ID><DEVICE_ID>IAOI01</DEVICE_ID><USER_ID>T1705016</USER_ID><BARCODE_ID>17050803.07.11</BARCODE_ID><TEST_TIME>2017/03/15 16:51:31</TEST_TIME><TEST_RESULT>OK</TEST_RESULT><DEFECT_CNT>10</DEFECT_CNT><O_SIZE_COUNT>1</O_SIZE_COUNT><L_SIZE_COUNT>2</L_SIZE_COUNT><M_SIZE_COUNT>3</M_SIZE_COUNT><S_SIZE_COUNT>4</S_SIZE_COUNT><TEST_PROGRAM>B140XTN02.235</TEST_PROGRAM><CENTERLV>2500</CENTERLV><IMAGE_FILE_PATH>D:\\Date\\20170515\\Images\\UZC7200107A130011_165131_00.png</IMAGE_FILE_PATH><CCD_NO>CCD_001</CCD_NO><DEFECT_INFO><DEFECT_CODE>DB12</DEFECT_CODE><DEFECT_DESC>BRIGHTPARTICLE</DEFECT_DESC><DEFECT_VALUE></DEFECT_VALUE><DEFECT_NUM>1</DEFECT_NUM><DEFECT_LOCATION_X>3</DEFECT_LOCATION_X><DEFECT_LOCATION_Y>3</DEFECT_LOCATION_Y><REVIEW>170728-6-21-3-27-0001.jpg</REVIEW><DATA_NO>113</DATA_NO><GATE_NO>18</GATE_NO><FLAG>0</FLAG><DEFECT_REAL_SIZE>45</DEFECT_REAL_SIZE><DEFECT_REAL_X_SIZE>45</DEFECT_REAL_X_SIZE><DEFECT_REAL_Y_SIZE>24</DEFECT_REAL_Y_SIZE><DEFECT_GRAY_LEVEL>24</DEFECT_GRAY_LEVEL><ZONE>2</ZONE><PI_NO>0</PI_NO><PANEL_ID>1</PANEL_ID></DEFECT_INFO><DEFECT_INFO><DEFECT_CODE>DB70</DEFECT_CODE><DEFECT_DESC>DARKPARTICLE</DEFECT_DESC><DEFECT_VALUE></DEFECT_VALUE><DEFECT_NUM>1</DEFECT_NUM><DEFECT_LOCATION_X>3</DEFECT_LOCATION_X><DEFECT_LOCATION_Y>3</DEFECT_LOCATION_Y><REVIEW>170728-6-21-3-27-0002.jpg</REVIEW><DATA_NO>113</DATA_NO><GATE_NO>18</GATE_NO><FLAG>0</FLAG><DEFECT_REAL_SIZE>45</DEFECT_REAL_SIZE><DEFECT_REAL_X_SIZE>45</DEFECT_REAL_X_SIZE><DEFECT_REAL_Y_SIZE>24</DEFECT_REAL_Y_SIZE><DEFECT_GRAY_LEVEL>24</DEFECT_GRAY_LEVEL><ZONE>2</ZONE><PI_NO>0</PI_NO><PANEL_ID>1</PANEL_ID></DEFECT_INFO></TRX>";
            try {
                //從XML中解析取得欄位資訊 並放入aoiInfo的資料結構中
                aoiInfo = getAOIInfoFromXML(sXML);

                //將解析到的資訊做資料檢查 , 並回傳檢查結果
                string strMsg = AOIInfoValidation(ref aoiInfo);

                
                if (strMsg == "") //空白表示通過Validation檢查 , 資料無異常
                {
                    //將分析並驗證過的資料Insert至DB
                    //Insert Into Hearder and Line Table
                    string sResult = InsertDataToAOIDB(aoiInfo);
                    
                }

                 message = Combine_AOI_RTN_Code(aoiInfo);


            }
            catch (Exception ex)
            {
                //當有Exception時 Send email to Admin
                string Admin = GetAdminMailAddress();
                StringBuilder sBody = new StringBuilder();
                string sTitle = "[FMM_WCF] " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                sBody.Append("Error Function : InsertAOIProcessData " + "<br>");
                sBody.Append("Error Message : " +  ex.ToString()  + "<br>");
                pb_ws.SendMail(Admin, "", "", sTitle, sBody.ToString());
            }

            return ReturnMessage(message);
        }

        public static string GetAdminMailAddress() // Second.Chen;Jeff.Huang
        {
            try
            {
                //Modify by Second 2016.04.20 Job Combine
                String AdminMailName = System.Configuration.ConfigurationManager.AppSettings.Get("Admin").ToString(); //從有@darwinprecisions.com 改到無@後字串
                return AdminMailName;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region ReturnMessage
        public string ReturnMessage(Message message)
        {
            StringBuilder strMsg = new StringBuilder();
            strMsg.Append("<TRX>");
            strMsg.Append("<TRX_NAME>" + message.TRX_NAME + "</TRX_NAME>");
            strMsg.Append("<TYPE_ID>" + message.TYPE_ID + "</TYPE_ID>");
            strMsg.Append("<LOG_ID>" + message.LOG_ID + "</LOG_ID>");
            strMsg.Append("<BARCODE_ID>" + message.BARCODE_ID + "</BARCODE_ID>");
            strMsg.Append("<RTN_CODE>" + message.RTN_CODE + "</RTN_CODE>");
            strMsg.Append("<RTN_MSG>" + message.RTN_MSG + "</RTN_MSG>");
            strMsg.Append("<RTN_CODE_MSG>" + message.RTN_CODE_MSG + "</RTN_CODE_MSG>");
            strMsg.Append("</TRX>");
            return strMsg.ToString();
        }
        #endregion ReturnMessage


        public Message Combine_AOI_RTN_Code(AOIInfo aoiInfo)
        {
            Message message = new Message();
            try {
                message.TRX_NAME = aoiInfo.TRX_NAME;
                message.TYPE_ID = aoiInfo.TYPE_ID;
                message.LOG_ID = aoiInfo.LOG_ID;
                message.BARCODE_ID = aoiInfo.BARCODE_ID;

                message.RTN_CODE = aoiInfo.RTN_CODE;
                message.RTN_MSG = aoiInfo.RTN_MSG;

                //根據RTN_MSG 取得錯誤訊息並塞入 message.RTN_CODE_MSG
                //message.RTN_CODE_MSG = GetRTN_ErrMsg(RTN_MSG);
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return message;
        }

        public string GetLotInfo(ref AOIInfo aoiInfo)
        {
            string sResult = string.Empty;
            string sFail = "FAIL";
            try
            {
                
                string BARCODE_ID, USER_ID ,DEVICE_ID = string.Empty;
                BARCODE_ID = aoiInfo.BARCODE_ID;
                USER_ID = aoiInfo.USER_ID;
                DEVICE_ID = aoiInfo.DEVICE_ID;
                
                DataSet ds = null;
                //DataTable dt = null;
                StringBuilder sSql = new StringBuilder();
                sSql.Append(" SELECT distinct USR_ID , E.class_id ");
                sSql.Append(" FROM C_USER_OPID C, emp_data_all E ");
                sSql.Append(" WHERE 1=1 ");
                sSql.Append(" and E.emp_no = C.USR_ID ");
                sSql.Append(" and  E.emp_no ='" + USER_ID + "'");
                ds = pb_ws.ExcuteSQL_Query("FMMDB_" + sEnvironment, sSql.ToString(), "CIMWCFService");
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    aoiInfo.SHIFT_ID = ds.Tables[0].Rows[0]["class_id"].ToString();
                }
                else
                {
                    sResult = "ERR_MSG_LOT_001";
                    aoiInfo.RTN_CODE = sFail;
                    aoiInfo.RTN_MSG = sResult;
                }

                //抓取FAB LINE EQP_TYPE 資料 , 從FMM MES DB
                sSql = new StringBuilder();
                sSql.Append(" SELECT distinct EQP_ID , EQP_TYPE , FAB , LINE , OP_ID ");
                sSql.Append(" FROM C_EQP_EQPT ");
                sSql.Append(" WHERE 1=1 ");
                sSql.Append(" and EQP_ID ='" + DEVICE_ID + "'");

                ds = pb_ws.ExcuteSQL_Query("FMMDB_" + sEnvironment, sSql.ToString(), "CIMWCFService");
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    aoiInfo.FAB = ds.Tables[0].Rows[0]["FAB"].ToString();
                    aoiInfo.LINE = ds.Tables[0].Rows[0]["LINE"].ToString();
                    aoiInfo.DEVICE_TYPE = ds.Tables[0].Rows[0]["EQP_TYPE"].ToString();
                    aoiInfo.STATION = ds.Tables[0].Rows[0]["OP_ID"].ToString();
                }
                else
                {
                    sResult = "ERR_MSG_LOT_002";
                    aoiInfo.RTN_CODE = sFail;
                    aoiInfo.RTN_MSG = sResult;
                }


                sSql = new StringBuilder();
                sSql.Append(" SELECT WO_ID , BARCODE_ID , MODEL_NO  ");
                sSql.Append(" FROM R_WOM_WOBARCODE ");
                sSql.Append(" WHERE 1=1 ");
                sSql.Append(" and BARCODE_ID ='" + BARCODE_ID + "'");

                ds = pb_ws.ExcuteSQL_Query("FMMDB_" + sEnvironment, sSql.ToString(), "CIMWCFService");
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    aoiInfo.WO = ds.Tables[0].Rows[0]["WO_ID"].ToString();
                    aoiInfo.MODEL_NAME = ds.Tables[0].Rows[0]["MODEL_NO"].ToString();
                }
                else
                {
                    sResult = "ERR_MSG_LOT_003";
                    aoiInfo.RTN_CODE = sFail;
                    aoiInfo.RTN_MSG = sResult;
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }

            return sResult;

        }


        public string InsertDataToAOIDB(AOIInfo aoiInfo)
        {
            DataSet ds = null;
            string sResult = string.Empty;
            try {
                StringBuilder strSql = new StringBuilder();
                strSql.Append(" Insert Into  " + "FMM_WCF_AOI_HEADER (");
                strSql.Append(" HEADER_ID , ");
                strSql.Append(" FAB , ");
                strSql.Append(" LINE , ");
                strSql.Append(" STATION , ");
                strSql.Append(" DEVICE_TYPE , ");
                strSql.Append(" MODEL_NAME , ");
                strSql.Append(" SHIFT_ID , ");
                strSql.Append(" WO , ");
                strSql.Append(" TRX_NAME , ");
                strSql.Append(" TYPE_ID , ");
                strSql.Append(" LOG_ID , ");
                strSql.Append(" DEVICE_ID , ");
                strSql.Append(" USER_ID , ");
                strSql.Append(" BARCODE_ID , ");
                strSql.Append(" TEST_TIME , ");
                strSql.Append(" TEST_RESULT , ");
                strSql.Append(" DEFECT_CNT , ");
                strSql.Append(" O_SIZE_COUNT , ");
                strSql.Append(" L_SIZE_COUNT , ");
                strSql.Append(" M_SIZE_COUNT , ");
                strSql.Append(" S_SIZE_COUNT , ");
                strSql.Append(" TEST_PROGRAM , ");
                strSql.Append(" CENTERLV , ");
                strSql.Append(" IMAGE_FILE_PATH , ");
                strSql.Append(" CCD_NO "); //最後一個參數不加入分隔符號
                strSql.Append(" ) ");
                strSql.Append(" Values ( ");

                strSql.Append("'" + aoiInfo.LOG_ID + "' , ");
                strSql.Append( "'" + aoiInfo.FAB + "' , ");
                strSql.Append( "'" + aoiInfo.LINE + "' , ");
                strSql.Append( "'" + aoiInfo.STATION + "' , ");
                strSql.Append( "N'" + aoiInfo.DEVICE_TYPE + "' , ");
                strSql.Append( "'" + aoiInfo.MODEL_NAME + "' , ");
                strSql.Append( "N'" + aoiInfo.SHIFT_ID + "' , ");
                strSql.Append( "'" + aoiInfo.WO + "' , ");
                strSql.Append( "'" + aoiInfo.TRX_NAME + "' , ");
                strSql.Append( "'" + aoiInfo.TYPE_ID + "' , ");
                strSql.Append( "'" + aoiInfo.LOG_ID + "' , ");
                strSql.Append( "'" + aoiInfo.DEVICE_ID + "' , ");
                strSql.Append( "'" + aoiInfo.USER_ID + "' , ");
                strSql.Append( "'" + aoiInfo.BARCODE_ID + "' , ");
                strSql.Append( "'" + aoiInfo.TEST_TIME + "' , ");
                strSql.Append( "'" + aoiInfo.TEST_RESULT + "' , ");
                strSql.Append( "'" + aoiInfo.DEFECT_CNT + "' , ");
                strSql.Append( "'" + aoiInfo.O_SIZE_COUNT + "' , ");
                strSql.Append( "'" + aoiInfo.L_SIZE_COUNT + "' , "); 
                strSql.Append( "'" + aoiInfo.M_SIZE_COUNT + "' , ");
                strSql.Append( "'" + aoiInfo.S_SIZE_COUNT + "' , ");
                strSql.Append( "'" + aoiInfo.TEST_PROGRAM + "' , ");
                strSql.Append( "'" + aoiInfo.CENTERLV + "' , ");
                strSql.Append( "'" + aoiInfo.IMAGE_FILE_PATH + "' , ");
                strSql.Append( "'" + aoiInfo.CCD_NO + "'"); //最後一個參數不加入分隔符號
                strSql.Append(" ) ");

                ds = pb_ws.ExcuteSQL_Query("CIMDB_" + sEnvironment, strSql.ToString(), "CIMWCFService");
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    sResult = "SUCCESS";
                }


                StringBuilder sbsql = new StringBuilder();
                List<string> ListSql = new List<string>();

                System.String[] aSql = null;
                if (aoiInfo.DefectLineInfo.Length > 0)
                {
                    for (int i = 0; i < aoiInfo.DefectLineInfo.Length; i++)
                    {
                        sbsql.Length = 0;
                        sbsql.Append(" Insert Into  " + "FMM_WCF_AOI_LINE (");
                        sbsql.Append(" LINE_ID , ");
                        sbsql.Append(" DEFECT_CODE , ");
                        sbsql.Append(" DEFECT_DESC , ");
                        sbsql.Append(" DEFECT_VALUE , ");
                        sbsql.Append(" DEFECT_NUM , ");
                        sbsql.Append(" DEFECT_LOCATION_X , ");
                        sbsql.Append(" DEFECT_LOCATION_Y , ");
                        sbsql.Append(" REVIEW , ");
                        sbsql.Append(" DATA_NO , ");
                        sbsql.Append(" GATE_NO , ");
                        sbsql.Append(" FLAG , ");
                        sbsql.Append(" DEFECT_REAL_SIZE , ");
                        sbsql.Append(" DEFECT_REAL_X_SIZE , ");
                        sbsql.Append(" DEFECT_REAL_Y_SIZE , ");
                        sbsql.Append(" DEFECT_GRAY_LEVEL , ");
                        sbsql.Append(" ZONE , ");
                        sbsql.Append(" PI_NO , ");
                        sbsql.Append(" PANEL_ID "); //最後一個參數不加入分隔符號
                        sbsql.Append(" ) ");
                        sbsql.Append(" Values ( ");

                        sbsql.Append("'" + aoiInfo.LOG_ID + "' , ");
                        sbsql.Append("'" + aoiInfo.DefectLineInfo[i].DEFECT_CODE + "' , ");
                        sbsql.Append("'" + aoiInfo.DefectLineInfo[i].DEFECT_DESC + "' , ");
                        sbsql.Append("'" + aoiInfo.DefectLineInfo[i].DEFECT_VALUE + "' , ");
                        sbsql.Append("'" + aoiInfo.DefectLineInfo[i].DEFECT_NUM + "' , ");
                        sbsql.Append("'" + aoiInfo.DefectLineInfo[i].DEFECT_LOCATION_X + "' , ");
                        sbsql.Append("'" + aoiInfo.DefectLineInfo[i].DEFECT_LOCATION_Y + "' , ");
                        sbsql.Append("'" + aoiInfo.DefectLineInfo[i].REVIEW + "' , ");
                        sbsql.Append("'" + aoiInfo.DefectLineInfo[i].DATA_NO + "' , ");
                        sbsql.Append("'" + aoiInfo.DefectLineInfo[i].GATE_NO + "' , ");
                        sbsql.Append("'" + aoiInfo.DefectLineInfo[i].FLAG + "' , ");
                        sbsql.Append("'" + aoiInfo.DefectLineInfo[i].DEFECT_REAL_SIZE + "' , ");
                        sbsql.Append("'" + aoiInfo.DefectLineInfo[i].DEFECT_REAL_X_SIZE + "' , ");
                        sbsql.Append("'" + aoiInfo.DefectLineInfo[i].DEFECT_REAL_Y_SIZE + "' , ");
                        sbsql.Append("'" + aoiInfo.DefectLineInfo[i].DEFECT_GRAY_LEVEL + "' , ");
                        sbsql.Append("'" + aoiInfo.DefectLineInfo[i].ZONE + "' , ");
                        sbsql.Append("'" + aoiInfo.DefectLineInfo[i].PI_NO + "' , ");
                        sbsql.Append("'" + aoiInfo.DefectLineInfo[i].PANEL_ID + "'"); //最後一個參數不加入分隔符號
                        sbsql.Append(" ) ");

                        ListSql.Add(sbsql.ToString());
                    }

                    int iResult = 0;
                    aSql = ListSql.ToArray();

                    if (aSql.Length > 0)
                    {
                        iResult = pb_ws.ExcuteSQL_Batch("CIMDB" + "_" + sEnvironment, aSql, "AP_JOB");
                    }
                }





            }
            catch (Exception ex)
            {
                throw ex;
            }
            return "";
        }



        public string InsertMicroscopeProcessData(string sXML)
        {
            MicroScopeInfo microScopeInfo = new MicroScopeInfo();
            sXML = "<TRX><TRX_NAME>InsertMicroscopeProcessData</TRX_NAME><TYPE_ID>IN</TYPE_ID><LOG_ID>17050803.07.11_20170829173900</LOG_ID><DEVICE_ID>IDIM02</DEVICE_ID><USER_ID>T1705016</USER_ID><BARCODE_ID>17050803.07.11</BARCODE_ID><TEST_TIME>2017.03.15 16:51:31</TEST_TIME><TEST_RECIPE_NAME>CGV-CN020-548G30V1-F850-OQC</TEST_RECIPE_NAME><USER_ID>T1705016</USER_ID><BARCODE_ID>170801.01.01</BARCODE_ID><MICROSCOPE><FIG_NAME>0001.JPG</FIG_NAME><COORDINATE_CODE>001</COORDINATE_CODE><COORDINATE_X>-51.569</COORDINATE_X><COORDINATE_Y>1.029</COORDINATE_Y><COORDINATE_R>51.579</COORDINATE_R><COORDINATE_T>178.856</COORDINATE_T><COORDINATE_Z>0.061</COORDINATE_Z><CONE_ANGLE>51.568</CONE_ANGLE><RADIUS>1.028</RADIUS><DIAMETER>51.571</DIAMETER><FLATNESS>178.857</FLATNESS><PERIMETER>0.061</PERIMETER><SPINDLE_X_LENGTH>0.031</SPINDLE_X_LENGTH><SPINDLE_Y_LENGTH>0.063</SPINDLE_Y_LENGTH><AREA>1.123</AREA><STARTING_ANGLE>30.112</STARTING_ANGLE><TERMINATION_ANGLE>40.112</TERMINATION_ANGLE><PROJECTION_DISTANCE_XY>1.012</PROJECTION_DISTANCE_XY><PROJECTION_DISTANCE_YZ>2.123</PROJECTION_DISTANCE_YZ><PROJECTION_DISTANCE_XZ>3.531</PROJECTION_DISTANCE_XZ><INNER_DIAMETER>5.123</INNER_DIAMETER><OUTER_DIAMETER>3.123</OUTER_DIAMETER><INNER_CIRCUMFERENCE>6.087</INNER_CIRCUMFERENCE><OUTER_CIRCUMFERENCE>8.948</OUTER_CIRCUMFERENCE><AVG_THICKNESS>0.054</AVG_THICKNESS><ELEVATION_ANGLE>31.113</ELEVATION_ANGLE><MEASUREMENT_TIME>2017/09/11 16:14:00</MEASUREMENT_TIME></MICROSCOPE><MICROSCOPE><FIG_NAME>0002.JPG</FIG_NAME><COORDINATE_CODE>001</COORDINATE_CODE><COORDINATE_X>-51.569</COORDINATE_X><COORDINATE_Y>1.029</COORDINATE_Y><COORDINATE_R>51.579</COORDINATE_R><COORDINATE_T>178.856</COORDINATE_T><COORDINATE_Z>0.061</COORDINATE_Z><CONE_ANGLE>51.568</CONE_ANGLE><RADIUS>1.028</RADIUS><DIAMETER>51.571</DIAMETER><FLATNESS>178.857</FLATNESS><PERIMETER>0.061</PERIMETER><SPINDLE_X_LENGTH>0.031</SPINDLE_X_LENGTH><SPINDLE_Y_LENGTH>0.063</SPINDLE_Y_LENGTH><AREA>1.123</AREA><STARTING_ANGLE>30.112</STARTING_ANGLE><TERMINATION_ANGLE>40.112</TERMINATION_ANGLE><PROJECTION_DISTANCE_XY>1.012</PROJECTION_DISTANCE_XY><PROJECTION_DISTANCE_YZ>2.123</PROJECTION_DISTANCE_YZ><PROJECTION_DISTANCE_XZ>3.531</PROJECTION_DISTANCE_XZ><INNER_DIAMETER>5.123</INNER_DIAMETER><OUTER_DIAMETER>3.123</OUTER_DIAMETER><INNER_CIRCUMFERENCE>6.087</INNER_CIRCUMFERENCE><OUTER_CIRCUMFERENCE>8.948</OUTER_CIRCUMFERENCE><AVG_THICKNESS>0.054</AVG_THICKNESS><ELEVATION_ANGLE>31.113</ELEVATION_ANGLE><MEASUREMENT_TIME>2017.09.11 16:15:00</MEASUREMENT_TIME></MICROSCOPE></TRX>";
            try
            {
                //microScopeInfo = getMicroScopeInfoFromXML(sXML);

                //string strMsg = MicroScopeInfoValidation(microScopeInfo);
                //Message message = new Message();
                //message.TRX_NAME = microScopeInfo.TRX_NAME;
                //message.TYPE_ID = microScopeInfo.TYPE_ID;
                //message.LOG_ID = microScopeInfo.LOG_ID;
                //message.BARCODE_ID = microScopeInfo.BARCODE_ID;


            }
            catch (Exception ex)
            {

                //send email
            }

            return "test" + "," + sXML;
        }






        //============================================================================================
        public AOIInfo getAOIInfoFromXML(string strXMLFile)
        {
            AOIInfo aoiInfo = new AOIInfo();
            DataSet ds = ConvertXMLFileToDataSet(strXMLFile);

            try
            {
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    aoiInfo.TRX_NAME = ds.Tables[0].Rows[0]["TRX_NAME"].ToString();
                    aoiInfo.TYPE_ID = ds.Tables[0].Rows[0]["TYPE_ID"].ToString();
                    aoiInfo.LOG_ID = ds.Tables[0].Rows[0]["LOG_ID"].ToString();
                    aoiInfo.DEVICE_ID = ds.Tables[0].Rows[0]["DEVICE_ID"].ToString();
                    aoiInfo.USER_ID = ds.Tables[0].Rows[0]["USER_ID"].ToString();
                    aoiInfo.BARCODE_ID = ds.Tables[0].Rows[0]["BARCODE_ID"].ToString();
                    aoiInfo.TEST_TIME = ds.Tables[0].Rows[0]["TEST_TIME"].ToString();
                    aoiInfo.TEST_RESULT = ds.Tables[0].Rows[0]["TEST_RESULT"].ToString();
                    aoiInfo.DEFECT_CNT = ds.Tables[0].Rows[0]["DEFECT_CNT"].ToString();
                    aoiInfo.O_SIZE_COUNT = ds.Tables[0].Rows[0]["O_SIZE_COUNT"].ToString();
                    aoiInfo.L_SIZE_COUNT = ds.Tables[0].Rows[0]["L_SIZE_COUNT"].ToString();
                    aoiInfo.M_SIZE_COUNT = ds.Tables[0].Rows[0]["M_SIZE_COUNT"].ToString();
                    aoiInfo.S_SIZE_COUNT = ds.Tables[0].Rows[0]["S_SIZE_COUNT"].ToString();
                    aoiInfo.TEST_PROGRAM = ds.Tables[0].Rows[0]["TEST_PROGRAM"].ToString();
                    aoiInfo.CENTERLV = ds.Tables[0].Rows[0]["CENTERLV"].ToString();
                    aoiInfo.IMAGE_FILE_PATH = ds.Tables[0].Rows[0]["IMAGE_FILE_PATH"].ToString();
                    aoiInfo.CCD_NO = ds.Tables[0].Rows[0]["CCD_NO"].ToString();



                    if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                    {
                        AOIDefectInfo[] lineinfo = new AOIDefectInfo[ds.Tables[1].Rows.Count];
                        for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                        {
                            lineinfo[i] = new AOIDefectInfo();
                            lineinfo[i].DEFECT_CODE = ds.Tables[1].Rows[i]["DEFECT_CODE"].ToString();
                            lineinfo[i].DEFECT_DESC = ds.Tables[1].Rows[i]["DEFECT_DESC"].ToString();
                            lineinfo[i].DEFECT_VALUE = ds.Tables[1].Rows[i]["DEFECT_VALUE"].ToString();
                            lineinfo[i].DEFECT_NUM = ds.Tables[1].Rows[i]["DEFECT_NUM"].ToString();
                            lineinfo[i].DEFECT_LOCATION_X = ds.Tables[1].Rows[i]["DEFECT_LOCATION_X"].ToString();
                            lineinfo[i].DEFECT_LOCATION_Y = ds.Tables[1].Rows[i]["DEFECT_LOCATION_Y"].ToString();
                            lineinfo[i].REVIEW = ds.Tables[1].Rows[i]["REVIEW"].ToString();
                            lineinfo[i].DATA_NO = ds.Tables[1].Rows[i]["DATA_NO"].ToString();
                            lineinfo[i].GATE_NO = ds.Tables[1].Rows[i]["GATE_NO"].ToString();
                            lineinfo[i].FLAG = ds.Tables[1].Rows[i]["FLAG"].ToString();
                            lineinfo[i].DEFECT_REAL_SIZE = ds.Tables[1].Rows[i]["DEFECT_REAL_SIZE"].ToString();
                            lineinfo[i].DEFECT_REAL_X_SIZE = ds.Tables[1].Rows[i]["DEFECT_REAL_X_SIZE"].ToString();
                            lineinfo[i].DEFECT_REAL_Y_SIZE = ds.Tables[1].Rows[i]["DEFECT_REAL_Y_SIZE"].ToString();
                            lineinfo[i].DEFECT_GRAY_LEVEL = ds.Tables[1].Rows[i]["DEFECT_GRAY_LEVEL"].ToString();
                            lineinfo[i].ZONE = ds.Tables[1].Rows[i]["ZONE"].ToString();
                            lineinfo[i].PI_NO = ds.Tables[1].Rows[i]["PI_NO"].ToString();
                            lineinfo[i].PANEL_ID = ds.Tables[1].Rows[i]["PANEL_ID"].ToString();

                        }
                        aoiInfo.DefectLineInfo = lineinfo;
                    }
                    else
                    {
                        AOIDefectInfo[] lineinfo = new AOIDefectInfo[0];
                        aoiInfo.DefectLineInfo = lineinfo;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return aoiInfo;
        }

        

        public string AOIInfoValidation(ref AOIInfo aoiInfo)
        {
            string sResult = string.Empty;
            try {

                //AOIInfoValidation檢查完畢之後才去執行GetLotInfo
                //利用BARCODE_ID、USER_ID、DEVICE_ID、串出FAB、LINE、DEVICE_TYPE、STATION、MODEL_NAME、SHIFT_ID
                sResult = GetLotInfo(ref aoiInfo);


                //有其他Validation可以寫在下方

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return sResult;
        }


        public MicroScopeInfo getMicroScopeInfoFromXML(string strXMLFile)
        {
            MicroScopeInfo microScopeInfo = new MicroScopeInfo();
            DataSet ds = ConvertXMLFileToDataSet(strXMLFile);

            try
            {
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    microScopeInfo.TRX_NAME = ds.Tables[0].Rows[0]["TRX_NAME"].ToString();
                    microScopeInfo.TYPE_ID = ds.Tables[0].Rows[0]["TYPE_ID"].ToString();
                    microScopeInfo.LOG_ID = ds.Tables[0].Rows[0]["LOG_ID"].ToString();
                    //microScopeInfo.USER_ID = ds.Tables[0].Rows[0]["USER_ID"].ToString();
                    microScopeInfo.BARCODE_ID = ds.Tables[0].Rows[0]["BARCODE_ID"].ToString();
                    microScopeInfo.TEST_TIME = ds.Tables[0].Rows[0]["TEST_TIME"].ToString();
                    microScopeInfo.TEST_RECIPE_NAME = ds.Tables[0].Rows[0]["TEST_RECIPE_NAME"].ToString();

                    if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                    {
                        MSMeasureInfo[] lineinfo = new MSMeasureInfo[ds.Tables[1].Rows.Count];
                        for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                        {
                            lineinfo[i] = new MSMeasureInfo();
                            lineinfo[i].FIG_NAME = ds.Tables[1].Rows[i]["FIG_NAME"].ToString();
                            lineinfo[i].COORDINATE_CODE = ds.Tables[1].Rows[i]["COORDINATE_CODE"].ToString();
                            lineinfo[i].COORDINATE_X = ds.Tables[1].Rows[i]["COORDINATE_X"].ToString();
                            lineinfo[i].COORDINATE_Y = ds.Tables[1].Rows[i]["COORDINATE_Y"].ToString();
                            lineinfo[i].COORDINATE_R = ds.Tables[1].Rows[i]["COORDINATE_R"].ToString();
                            lineinfo[i].COORDINATE_T = ds.Tables[1].Rows[i]["COORDINATE_T"].ToString();
                            lineinfo[i].COORDINATE_Z = ds.Tables[1].Rows[i]["COORDINATE_Z"].ToString();
                            lineinfo[i].CONE_ANGLE = ds.Tables[1].Rows[i]["CONE_ANGLE"].ToString();
                            lineinfo[i].RADIUS = ds.Tables[1].Rows[i]["RADIUS"].ToString();
                            lineinfo[i].DIAMETER = ds.Tables[1].Rows[i]["DIAMETER"].ToString();
                            lineinfo[i].FLATNESS = ds.Tables[1].Rows[i]["FLATNESS"].ToString();
                            lineinfo[i].PERIMETER = ds.Tables[1].Rows[i]["PERIMETER"].ToString();
                            lineinfo[i].SPINDLE_X_LENGTH = ds.Tables[1].Rows[i]["SPINDLE_X_LENGTH"].ToString();
                            lineinfo[i].SPINDLE_Y_LENGTH = ds.Tables[1].Rows[i]["SPINDLE_Y_LENGTH"].ToString();
                            lineinfo[i].SPINDLE_Z_LENGTH = ds.Tables[1].Rows[i]["SPINDLE_Z_LENGTH"].ToString();
                            lineinfo[i].AREA = ds.Tables[1].Rows[i]["AREA"].ToString();
                            lineinfo[i].STARTING_ANGLE = ds.Tables[1].Rows[i]["STARTING_ANGLE"].ToString();
                            lineinfo[i].TERMINATION_ANGLE = ds.Tables[1].Rows[i]["TERMINATION_ANGLE"].ToString();
                            lineinfo[i].PROJECTION_DISTANCE_XY = ds.Tables[1].Rows[i]["PROJECTION_DISTANCE_XY"].ToString();
                            lineinfo[i].PROJECTION_DISTANCE_YZ = ds.Tables[1].Rows[i]["PROJECTION_DISTANCE_YZ"].ToString();
                            lineinfo[i].PROJECTION_DISTANCE_XZ = ds.Tables[1].Rows[i]["PROJECTION_DISTANCE_XZ"].ToString();
                            lineinfo[i].INNER_DIAMETER = ds.Tables[1].Rows[i]["INNER_DIAMETER"].ToString();
                            lineinfo[i].OUTER_DIAMETER = ds.Tables[1].Rows[i]["OUTER_DIAMETER"].ToString();
                            lineinfo[i].INNER_CIRCUMFERENCE = ds.Tables[1].Rows[i]["INNER_CIRCUMFERENCE"].ToString();
                            lineinfo[i].OUTER_CIRCUMFERENCE = ds.Tables[1].Rows[i]["OUTER_CIRCUMFERENCE"].ToString();
                            lineinfo[i].AVG_THICKNESS = ds.Tables[1].Rows[i]["AVG_THICKNESS"].ToString();
                            lineinfo[i].ELEVATION_ANGLE = ds.Tables[1].Rows[i]["ELEVATION_ANGLE"].ToString();
                            lineinfo[i].MEASUREMENT_TIME = ds.Tables[1].Rows[i]["MEASUREMENT_TIME"].ToString();

                        }
                        microScopeInfo.MSLineInfo = lineinfo;
                    }
                    else
                    {
                        MSMeasureInfo[] lineinfo = new MSMeasureInfo[0];
                        microScopeInfo.MSLineInfo = lineinfo;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return microScopeInfo;
        }


        public string MicroScopeInfoValidation(MicroScopeInfo microScopeInfo)
        {
            try
            {



            }
            catch (Exception ex)
            {
                throw ex;
            }

            return "";
        }

        public static DataSet ConvertXMLFileToDataSet(string xmlFile)
        {
            StringReader stream = null;
            XmlTextReader reader = null;
            try
            {
                DataSet xmlDS = new DataSet();
                stream = new StringReader(xmlFile);
                reader = new XmlTextReader(stream);
                xmlDS.ReadXml(reader);
                return xmlDS;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (reader != null) reader.Close();
            }
        }


        public static string GetEnvironment()
        {
            try
            {
                //Modify by Second 2017.09.26
                String sEnvironment = System.Configuration.ConfigurationManager.AppSettings.Get("Environment").ToString(); //從有@darwinprecisions.com 改到無@後字串
                return sEnvironment;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static void WriteLogTxt(String Module, String Status, String txt, String FunctionName)
        {
            try
            {
                /*檢查Log資料夾是否存在*/
                if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "Log\\" + FunctionName)))
                {
                    /*如果沒有Log資料夾，則新建一個*/
                    Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "Log\\" + FunctionName));
                }

                /*Log檔日期格式*/
                string Year = String.Format("{0:yyyy}", DateTime.Now);
                string Month = String.Format("{0:MM}", DateTime.Now);
                string Day = String.Format("{0:dd}", DateTime.Now);
                string Time = Year + "_" + Month + "_" + Day;

                /*檢查Log資料夾內的年資料夾是否存在*/
                if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "Log\\" + FunctionName + "\\" + Year)))
                {
                    /*如果Log資料夾內的年資料夾沒有年資料夾，則新建一個*/
                    Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "Log\\" + FunctionName + "\\" + Year));
                }

                /*檢查Log資料夾內的年資料夾內的月資料夾是否存在*/
                if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "Log\\" + FunctionName + "\\" + Year + "\\" + Month)))
                {
                    /*如果Log資料夾內的年資料夾的年資料夾內沒有月資料夾，則新建一個*/
                    Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "Log\\" + FunctionName + "\\" + Year + "\\" + Month));
                }

                /*寫入文字檔*/
                /*訊息前加入時、分、秒與辨識字首*/
                string LogFormat = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " ==> ";
                using (StreamWriter sw = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory() + "\\Log\\" + FunctionName + "\\" + Year + "\\" + Month, Time + ".log"), true))
                {
                    sw.WriteLine(LogFormat + " Module: " + Module + " Status: " + Status + " Desc: " + txt);
                }
                //同步顯示於Console
                Console.WriteLine(txt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
