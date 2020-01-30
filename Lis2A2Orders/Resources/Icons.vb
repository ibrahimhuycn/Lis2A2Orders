Imports System.IO

Public Class Icons

    Const _disconnected As String = "iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAABmJLR0QA/wD/AP+gvaeTAAACTUlEQVRIDeWUu2sUURSHv7gxsVPRFL4ao4hiQAsb3yIhf4BsJdubVCviYvwH1BRJGo3WQioJil2a4KtJFIMBFTRWElDwBSImJqzfnd0Zh3Ufo504nPf9nXPuufcy8K9/bX8zQBHWdcCwuX3yV4sMX4Ebg9C1AqeG4LrxiFyLdGZxETYtw5QJu+Q03dTZJ/dYdMCGY9q0B5GFS3BG8EOL3xJfW9wQhSDkuVUQMJpka2DxAdFXf8Ciu+vUbkbPBHyIATaLzcZ6CcZdnc1QXBinv0HYULDJ1GAUPrv7fBneRlmtRTGGZGoQXsdqmHCCrSZmabJWXER1G5S80FA0QihWIK/qkeec5IR6Vm5Gd+PF3xpYPJzfmEXvxU2G4JoJ/Tk4OQKvvZOGTdrgubjz4iPSj3QiirDb43jqQqdn/kZ9xAYLCaBqnIUd4qZ0w7GpInrijnsvw6fIU+grq2TSlg64Y1FfGqi3l+FBCTZXIZEKk1l8QicUj+/ku34hXVz/1ysyaYPFJw3ulBMKTXTup5t4fHlj0Z14HL3aL+Q1Yo9T8yUTLPtvcbd7atZjt1sjaTKUupNL8DIHx1zvj38P2gnZtGK7w49a6+WGVIZ5E47aYKEhqGYhmcD4F7kpWbxbQDKJdktKNxhpia4A/qhJrpIDj2D6IGxzl/vjWAO9aLxL3Lw5j7WbUjLBIGw06UAztHcwI4fXU/dC6+W2x8H00zM2KZ+T0zTtb6Jv1B+fwVdyJkof0cwheGfggs/t9mF4b4W9ThWmHF+CQrW44f+JfgLA4Hoiuq4J5wAAAABJRU5ErkJggg=="

    Const _connected As String = "iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAABmJLR0QA/wD/AP+gvaeTAAAC3ElEQVRIDe1US0hUURj+zp0ZtUWZPZwYlVy5MW2VGw0ELVoW9EJ3rcJVEGSjmwshSpCtgnBdCBW26LEoyiBXTi40XSWkqJNOFqVIajP39P13xjv3zr2S4C66/M/zv875z38P8P9zdeBIHIcrunHVtYSQW9mNLMmZ7A1zXNnXhNTqCD5QRljITrHaxP70Ju5o4AxjVpVC/3wPBqpuIGYpDHOthpiIFGOQ3AZl0x2QmIlDahOyw3qPu4UBGGgGkE1ehNMzJn5Qt+GvBaSn2sI7Oj6CQp3WmDJCOAeNesoPmaWYCOofM0DLYi++2nqOhHM8kFV08agal5k8yeQxOk1mitGSNJGi/KnyJta0gaeUS+gzyuTLlD3Ae/HojhLrRgeDOrmzX0x+gLikMjj7pQeft5xWRjC9txEJ3sV52htKT+LbynuMbtmFG0KC0FB4rYFZBu6hfZ2FojqEJ3Kh1B1I9uEVbRdlgf7XhLsxsEDURDn7PsQTHGXQLANKiOvEGiuM4cIibNM4bQKlQtzoK1ARx8HQBt7S6RhxwrDQSp4gBhaJyXRpPKdd4JkQN/oKsCX97Gkt+bguQst8H6YjHD0G+YpUdqJOZTcjEzWlinCdfh5QHo0KJ+c7WRnSqFq4jXnKNlTzJ/u9yX4DJ7gg7SrRCimlUU59Ms3NLGWni2oe/CcAftrmMI7bPEdm+PMUnsROriDT1RaUXEJ9Bdieu2IgPo514RS5A1JEGWh3XfwGJyjKS25ynAoE338gc8x5rqJfA/t3obQRYzLv1BHldBlpvOR6DRPLz1emNQaTvYiLPQjp6112XkU+CznLOlvRnjEwpiy84AlruT7BxJd4muaFHtynvi14Csh8y5zT2364OEkJ7rSDeh4UxnUErUkTy/nF7SWnRYXJ5ULnbmGIb/siC9VxJwZ3/yASQducCZm07bO6LIzLavbbo3GPOw58FbNeu6TyNMsd7DLNPxb+B3tz3vxkoBR0AAAAAElFTkSuQmCC"

    ReadOnly Property Connected As String
        Get
            Return _connected
        End Get
    End Property
    ReadOnly Property Disconnected As String
        Get
            Return _disconnected
        End Get
    End Property

    Public Shared Function GetIcon(base64image As String) As Image
        Dim bytes As Byte() = Convert.FromBase64String(base64image)
        Dim image As Image

        Using ms As MemoryStream = New MemoryStream(bytes)
            image = Image.FromStream(ms)
        End Using
        Return image

    End Function
End Class
