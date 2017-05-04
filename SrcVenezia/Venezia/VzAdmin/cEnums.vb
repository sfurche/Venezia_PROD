Imports System.Xml.Serialization

<Serializable()> Public Class cEnums

    Public Enum enuBinario
        <XmlEnum("Si")> Si = 1
        <XmlEnum("No")> No = 1
        <XmlEnum("Null")> Null = 1
    End Enum

End Class
