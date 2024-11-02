namespace WebApplication2.Def.Enum
{
    public enum CustomReturnResultCodeEnum : int
    {
        /// <summary>
        /// No Error
        /// </summary>
        NoError = -1,

        #region User Login 10001 - 10099
        /// <summary>
        /// Username and Password Not Match
        /// </summary>
        UserNameAndPasswordNotMatch = 10001,
        #endregion

        /// <summary>
        /// Other
        /// </summary>
        Other = 11111
    }
}
