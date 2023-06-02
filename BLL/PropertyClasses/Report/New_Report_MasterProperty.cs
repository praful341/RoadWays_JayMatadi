using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.PropertyClasses.Report
{//asds


    public class New_Report_MasterProperty
    {
        private int _Report_code;
        public int Report_code
        {
            get { return _Report_code; }
            set { _Report_code = value; }
        }

        private string _Report_Name;
        public string Report_Name
        {
            get { return _Report_Name; }
            set { _Report_Name = value; }
        }

        private string _Report_Group_Name;
        public string Report_Group_Name
        {
            get { return _Report_Group_Name; }
            set { _Report_Group_Name = value; }
        }

        private string _Form_Name;
        public string Form_Name
        {
            get { return _Form_Name; }
            set { _Form_Name = value; }
        }


        private int _Sequence_No;
        public int Sequence_No
        {
            get { return _Sequence_No; }
            set { _Sequence_No = value; }
        }

        private int _Active;

        public int Active
        {
            get { return _Active; }
            set { _Active = value; }
        }

        private string _Remark;

        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }

        public string Disp_In { get; set; }
      
    }

    public class New_Report_DetailProperty
    {
        private int _Report_code;
        public int Report_code
        {
            get { return _Report_code; }
            set { _Report_code = value; }
        }

        
        private string _Report_Type;
        public string Report_Type
        {
            get { return _Report_Type; }
            set { _Report_Type = value; }
        }

        private string _Procedure_Name;
        public string Procedure_Name
        {
            get { return _Procedure_Name; }
            set { _Procedure_Name = value; }
        }

        private string _Report_Header_Name;
        public string Report_Header_Name
        {
            get { return _Report_Header_Name; }
            set { _Report_Header_Name = value; }
        }

        private string _Rpt_Name;
        public string Rpt_Name
        {
            get { return _Rpt_Name; }
            set { _Rpt_Name = value; }
        }


        private string _Default_Order_By;
        public string Default_Order_By
        {
            get { return _Default_Order_By; }
            set { _Default_Order_By = value; }
        }

        private string _Default_Group_By;
        public string Default_Group_By
        {
            get { return _Default_Group_By; }
            set { _Default_Group_By = value; }
        }

        private int _Active;

        public int Active
        {
            get { return _Active; }
            set { _Active = value; }
        }

        private string _Remark;

        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }

        private int _Is_Pivot;

        public int Is_Pivot
        {
            get { return _Is_Pivot; }
            set { _Is_Pivot = value; }
        }


        private string _Font_Name;

        public string Font_Name
        {
            get { return _Font_Name; }
            set { _Font_Name = value; }
        }

        private double _Font_Size;

        public double Font_Size
        {
            get { return _Font_Size; }
            set { _Font_Size = value; }
        }


        private string _Page_Orientation;

        public string Page_Orientation
        {
            get { return _Page_Orientation; }
            set { _Page_Orientation = value; }
        }

        private string _Page_Kind;

        public string Page_Kind
        {
            get { return _Page_Kind; }
            set { _Page_Kind = value; }
        }

        private double _Autofit;

        public double Autofit
        {
            get { return _Autofit; }
            set { _Autofit = value; }
        }


    }

    public class New_Report_SettingsProperty
    {

        private int _Report_code;
        public int Report_code
        {
            get { return _Report_code; }
            set { _Report_code = value; }
        }

        private string _Report_Type;
        public string Report_Type
        {
            get { return _Report_Type; }
            set { _Report_Type = value; }
        }

        private int _Field_No;
        public int Field_No
        {
            get { return _Field_No; }
            set { _Field_No = value; }
        }

        private string _Field_Name;
        public string Field_Name
        {
            get { return _Field_Name; }
            set { _Field_Name = value; }
        }

        private string _Column_Name;
        public string Column_Name
        {
            get { return _Column_Name; }
            set { _Column_Name = value; }
        }

        private string _Aggregate;
        public string Aggregate
        {
            get { return _Aggregate; }
            set { _Aggregate = value; }
        }

        private string _Alignment;
        public string Alignment
        {
            get { return _Alignment; }
            set { _Alignment = value; }
        }

        private string _Format;
        public string Format
        {
            get { return _Format; }
            set { _Format = value; }
        }

        private int _Width;
        public int Width
        {
            get { return _Width; }
            set { _Width = value; }
        }

        private int _Column_Width;
        public int Column_Width
        {
            get { return _Column_Width; }
            set { _Column_Width = value; }
        }

        private int _Visible;
        public int Visible
        {
            get { return _Visible; }
            set { _Visible = value; }
        }

        private int _IsMerge;
        public int IsMerge
        {
            get { return _IsMerge; }
            set { _IsMerge = value; }
        }

        private string _MergeOn;
        public string MergeOn
        {
            get { return _MergeOn; }
            set { _MergeOn = value; }
        }

        private string _Type;
        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }


        private int _Sequence_No;
        public int Sequence_No
        {
            get { return _Sequence_No; }
            set { _Sequence_No = value; }
        }

        private int _Active;

        public int Active
        {
            get { return _Active; }
            set { _Active = value; }
        }

        private string _Remark;

        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }

        private int _Is_Group;

        public int Is_Group
        {
            get { return _Is_Group; }
            set { _Is_Group = value; }
        }

        private int _Is_Row_Area;

        public int Is_Row_Area
        {
            get { return _Is_Row_Area; }
            set { _Is_Row_Area = value; }
        }

        private int _Is_Column_Area;

        public int Is_Column_Area
        {
            get { return _Is_Column_Area; }
            set { _Is_Column_Area = value; }
        }

        private int _Is_Data_Area;

        public int Is_Data_Area
        {
            get { return _Is_Data_Area; }
            set { _Is_Data_Area = value; }
        }

        private string _Order_By;

        public string Order_By
        {
            get { return _Order_By; }
            set { _Order_By = value; }
        }


        private int _Is_Unbound;
        public int Is_Unbound
        {
            get { return _Is_Unbound; }
            set { _Is_Unbound = value; }
        }

        private string _Expression;
        public string Expression
        {
            get { return _Expression; }
            set { _Expression = value; }
        }

        private string _Bands;

        public string Bands
        {
            get { return _Bands; }
            set { _Bands = value; }
        }

        // Add : Narendra : 03-12-2014

        private string _Themes_Name;

        public string Themes_Name
        {
            get { return _Themes_Name; }
            set { _Themes_Name = value; }
        }

        private int _Employee_Code;
        public int Employee_Code
        {
            get { return _Employee_Code; }
            set { _Employee_Code = value; }
        }

        private string _Grid_Or_Pivot_Name;

        public string Grid_Or_Pivot_Name
        {
            get { return _Grid_Or_Pivot_Name; }
            set { _Grid_Or_Pivot_Name = value; }
        }

        private int _Is_Bold;
        public int Is_Bold
        {
            get { return _Is_Bold; }
            set { _Is_Bold = value; }
        }

        private int _Is_Italic;
        public int Is_Italic
        {
            get { return _Is_Italic; }
            set { _Is_Italic = value; }
        }

        private int _Is_Underline;
        public int Is_Underline
        {
            get { return _Is_Underline; }
            set { _Is_Underline = value; }
        }


        private string _BackColor;

        public string BackColor
        {
            get { return _BackColor; }
            set { _BackColor = value; }
        }

        private string _ForColor;

        public string ForColor
        {
            get { return _ForColor; }
            set { _ForColor = value; }
        }

        private string _GridColor;

        public string GridColor
        {
            get { return _GridColor; }
            set { _GridColor = value; }
        }
        private int _Active_Theme;
        public int Active_Theme
        {
            get { return _Active_Theme; }
            set { _Active_Theme = value; }
        }

        private string _Filter_Expression;

        public string Filter_Expression
        {
            get { return _Filter_Expression; }
            set { _Filter_Expression = value; }
        }

        private string _Grid_Theme;

        public string Grid_Theme
        {
            get { return _Grid_Theme; }
            set { _Grid_Theme = value; }
        }

        // End : Narendra : 03-12-2014
    }



}
