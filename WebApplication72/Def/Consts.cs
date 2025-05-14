namespace WebApplication72.Def
{
    public class Consts
    {
        #region Session
        public const string SessionKey_LoginUser = "LoginUser";
        #endregion

        #region Jwt
        public const string JWT_Issuer = "WebApplication72.Issuer";       // 颁发者        
        public const string JWT_Audience = "WebApplication72.Audience";   // 接收者        
        public const string JWT_Secret = "4A9A70D2-B8AD-42E1-B002-553BDEF4E76F";    // 签名秘钥        
        public const int JWT_AccessExpiration = 20;     // AccessToken过期时间, 单位: minute
        #endregion

        #region Union Result Code
        public const int URC_Success = 0;
        #region User Login
        public const int URC_UserLogin_InvalidUserNamePwd = 100100 + 1;
        public const int URC_UserLogin_InvalidVeryCode = 100100 + 2;
        #endregion

        #region Order
        public const int URC_Order = 100200;
        /// <summary>
        /// 
        /// </summary>
        public const int URC_Order_InvalidOrderNo = URC_Order + 1;
        /// <summary>
        /// 
        /// </summary>
        public const int URC_Order_Invalid = URC_Order + 2;
        #endregion
        #endregion
    }
}
