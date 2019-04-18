namespace BCL.ToolLib.Attribute
{
    /// <summary>
    /// 是否需要验证
    /// true 需要验证 false 不需要验证
    /// </summary>
    public class IsValidateAttribute : System.Attribute
    {
        private bool _b { get; set; }
        public IsValidateAttribute(bool b = true)
        {
            _b = b;
        }

        public bool IsValidate
        {
            get { return _b; }
        }
    }
}
