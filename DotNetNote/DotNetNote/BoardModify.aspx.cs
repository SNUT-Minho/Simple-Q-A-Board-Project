using System;

namespace DotNetNote.DotNetNote
{
    public partial class BoardModify : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BoardEditorFormControl.FormType = Models.BoardWriteFormType.Modify;
            
        }
    }
}