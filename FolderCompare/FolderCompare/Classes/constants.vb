Option Explicit On
Option Strict On

Public NotInheritable Class Constants

    'Row State Colors
    Public rowStateModified As Color = Color.Crimson
    'Public rowStateUnchanged As Color = Color.White
    Public rowStateDeleted As Color = Color.BurlyWood
    Public rowstateAdded As Color = Color.LightBlue


    Public AlternatingRowBackColor As Color = Color.Bisque

    'Strings
    Public Const kRequiredFiles As String = "Please ensure the base and destination files have been selected prior to requesting a file comparison"
    Public Const kSchemaIsNotCorrect As String = "One or both of the files selected do not have the correct schema definition. Please regenerate your source files for comparison or choose source files that have the correct schema."
    Public Const kBaseFileLocationIncorrect As String = "The base file location is incorrect. Please choose a valid base file."
    Public Const kDestinationFileLocationIncorrect As String = "The destination file location is incorrect. Please choose a valid base file."

    'Allow the caller to edit up to two parameters of the file
    Public Const kDefaultFileComparisonFileName As String = "m500cmp{0}{1}"

    Public Const kAllUserConfigFileLocation As String = "C:\Documents and Settings\All Users\Application Data\Sage Software\Sage MAS 500\Application.Config"
    Public Const kInvalidSqlStatement As String = "Invalid SQL Statement"

    Public Const kEmailSuccessfullySent As String = "An email has been successfully sent"
    Public Const kEmailingSupport As String = "Emailing Support"
    Public Const kInvalidEmailAddr As String = "The email address you entered is not valid, please reenter"
    Public Const kFromEmailRequired As String = "From email, as defined in the application settings, is a required field and must conform to a valid email address."
    Public Const kToEmailRequired As String = "To email, as defined in the application settings, is a required field and must conform to a valid email address."
    Public Const kFromToEmailRequired As String = "Either the from or to email addresses are empty or do not conform to valid email addresses, as defined in the application settings. Please define a valid from and to email address"

    Public Enum EmailValidation
        EmailIsValid = 0
        InvalidFromAddress = 1
        InvalidToAddress = 2
    End Enum

    Public Const kRequiredFields As String = "{0} is a required field"
    Public Const kCaseNumberRequired As String = "Case number is a required field"
    Public Const kQueryMapFileName As String = "Queries\QueryMap.xml"
    Public Const kCompressedFileExtension As String = ".ccf"
    Public Const kNoFileSelectedForEdit As String = "No file was selected for editing"
    Public Const kNothingToSave As String = "There is nothing to save"
    Public Const kFileDoesNotExist As String = "File does not exist: {0}"
    Public Const kComparingFilesNow As String = "Comparing files now"
    Public Const kScanningSelectedFolder As String = "Scanning selected folder"
    Public Const kDirectoryInvalid As String = "Directory {0} is invalid"


    Public Const CurrentVersion As String = "7.40.0.0"
    Public Const CurrentVersionShort As String = "7.40"
    Public Const ProductName As String = "Sage MAS 500"
    Public Const ProductFullName As String = "Sage ERP MAS 500"
    Public Const ProductShortName As String = "MAS 500"
    Public Const ProductID As String = "6E79D45A-2E46-4945-BD33-7D08DB46817D"  ' Used for Common Desktop product registration ???, don't what is this for
    ' Used for Common Desktop product registration https://commondesktop.bestsoftware.com/InformationCenter/Updates.xml. WL 09/20/05
    Public Const ApplicationStartPageID As String = "71c81070-f96a-4f2b-b13b-0f8a1316f41c"
    Public Const CompanyName As String = "Sage Software, Inc."
    Public Const Copyright As String = "Copyright(c) 1995-2011 " & CompanyName
    Public Const CompanyMediumName As String = "Sage Software"
    Public Const CompanyShortName As String = "Sage"
    Public Const DesktopName As String = ProductShortName & " Desktop"
    Public Const DefaultSysDSNName As String = "MAS 500"
    Public Const DefaultAppDSNName As String = "MAS 500"
    Public Const SupportHelpFile As String = "SM.Chm"

    Public Const GridTemplatesSubDir As String = "GridTemplates"

    Public Const DefaultAppDataSubFolder As String = CompanyMediumName

    Public Const ApplicationRegistryRoot As String = "SOFTWARE\State Of The Art\Acuity Financials\0.0"
    Public Const ApplicationProjectRegistryRoot As String = "SOFTWARE\State Of The Art\Acuity Financials\0.0\PAMSP"

    ' *** Default login timeout is 30 seconds
    Public Const DefaultLoginTimeout As Integer = 30
    ' *** Default query timeout is 2 minutes
    Public Const DefaultQueryTimeout As Integer = (2 * 60)

    Public Enum LoginOption
        ChangeAll = 0
        ChangeUser = 1
        ChangeCompany = 2
        ChangeNone = 3
    End Enum

    '********************************************************************
    ' DataType - Defines the data type in MAS 500 data dictionary tables
    '********************************************************************
    Public Enum DataType
        [CHAR] = 1
        [NUMERIC] = 2
        [DECIMAL] = 3
        [INTEGER] = 4
        [SMALLINT] = 5
        [FLOAT] = 6
        [REAL] = 7
        [DOUBLE] = 8
        [DATE] = 9
        [TIME] = 10
        [TIMESTAMP] = 11
        [VARCHAR] = 12
        [TEXT] = -1
        [BINARY] = -2
        [IMAGE] = -4
        [BIGINT] = -5
        [TINYINT] = -6
        [BIT] = -7
        [UNIQUEIDENTIFIER] = -11
        [VARBINARY] = -12
    End Enum

    '*********************************************************
    ' The SQL Server data types in systypes table (xtype)
    '*********************************************************
    Public Enum SQLServerDataType
        [BIGINT] = 127
        [BINARY] = 173
        [BIT] = 104
        [CHAR] = 175
        [DATETIME] = 61
        [DECIMAL] = 106
        [FLOAT] = 62
        [IMAGE] = 34
        [INT] = 56
        [MONEY] = 60
        [NCHAR] = 239
        [NTEXT] = 99
        [NUMERIC] = 108
        [NVARCHAR] = 231
        [REAL] = 59
        [SMALLDATETIME] = 58
        [SMALLINT] = 52
        [SMALLMONEY] = 122
        [SQL_VARIANT] = 98
        [SYSNAME] = 231
        [TEXT] = 35
        [TIMESTAMP] = 189
        [TINYINT] = 48
        [UNIQUEIDENTIFIER] = 36
        [VARBINARY] = 165
        [VARCHAR] = 167
    End Enum

    '*********************************************************
    ' Type of task rights user may have
    '*********************************************************
    Public Enum UserTaskRights
        Excluded = 1
        DisplayOnly = 2
        Normal = 3
        Supervisory = 4
    End Enum

    '*********************************************************
    ' Type of mask column may have
    '*********************************************************
    Public Enum MaskType
        [None] = 0
        [GeneralNumber] = 1
        [Currency] = 2
        [Percent] = 3
        [Quantity] = 4
        [UnitCost] = 5
        [UnitPrice] = 6
        [ShortDate] = 7
        [Text] = 8
        [PhoneNo] = 9
        [GLAccountNo] = 10
        [PostalCode] = 11
        [Float] = 12
        [General] = 13
        [LongDate] = 14
        [URL] = 15
        [GeneralDate] = 16
        [ShortTime] = 17
        [LongTime] = 18
    End Enum

    Public MustInherit Class MaskID
        Public Const [GeneralNumber] As String = "General Number"
        Public Const [Currency] As String = "Currency"
        Public Const [Percent] As String = "Percent"
        Public Const [Quantity] As String = "Quantity"
        Public Const [UnitCost] As String = "Unit Cost"
        Public Const [UnitPrice] As String = "Unit Price"
        Public Const [ShortDate] As String = "Short Date"
        Public Const [Text] As String = "Text"
        Public Const [PhoneNo] As String = "Phone No"
        Public Const [GLAccountNo] As String = "GL Account No"
        Public Const [PostalCode] As String = "Postal Code"
        Public Const [Float] As String = "Float"
        Public Const [General] As String = "General"
        Public Const [LongDate] As String = "Long Date"
        Public Const [URL] As String = "URL"
        Public Const [GeneralDate] As String = "General Date"
        Public Const [ShortTime] As String = "Short Time"
        Public Const [LongTime] As String = "Long Time"
        Public Const [StockQty] As String = "Stock Quantity"
        Public Const [Diagram] As String = "Diagram"
    End Class

    Public Enum TaskLaunchTypes
        COM1 = 0
        COM2 = 1
        Standard = 2
        Security = 3
        WinApp = 4
        DotNETStandard = 5
    End Enum

    Public Enum TaskTypes
        Maintenance = 1
        AddOnTheFly = 2
        DrillAround = 3
        DrillDown = 4
        DataEntry = 5
        Activity = 6
        Posting = 7
        Processing = 8
        Report = 9
        Listing = 10
        Register = 11
        PeriodEnd = 12
        Utility = 13
        WebReport = 14
        DataAnalysis = 15
        CustomReport = 16
        Security = 17
        DataExplorer = 18
        VisualIntegrator = 19
    End Enum

    Public Enum SaveToRegistryOptions
        SaveAsDefaultOn = 0
        SaveAsDefaultOff = 1
    End Enum

    ''' <summary>
    ''' All paths assume client install location as parent
    ''' </summary>
    ''' <remarks></remarks>
    Public MustInherit Class Paths
        Public Const Separator As Char = "\"c
        Public Const Help As String = "Help"
        Public Const ManagedApps As String = "Managed Applications"
        Public Const RepData As String = "RepData"
        Public Const SampleReports As String = "Sample Custom Reports"
        Public Const Tutorials As String = "Tutorials\Bin"
        Public Const UserGuides As String = "User Guides"
    End Class
End Class

