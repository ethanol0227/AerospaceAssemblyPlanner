Public Class PrecedenceStore
    Private Shared Function DefaultConfig() As PrecedenceConfig
        Dim cfg As New PrecedenceConfig()

        ' NEW ORDER / NEW OpTypes
        cfg.Tiers.Clear()

        ' 1 Chamfer/Relief + Countersink
        cfg.Tiers.Add(New PrecedenceTier With {
        .Name = "1 Chamfer/Relief + Countersink",
        .OpTypes = New List(Of String) From {
            "Chamfer/Relief",
            "Countersink"
        }
    })

        ' 2 SurfacePrep
        cfg.Tiers.Add(New PrecedenceTier With {
        .Name = "2 SurfacePrep",
        .OpTypes = New List(Of String) From {
            "SurfacePrep"
        }
    })

        ' 3 AdhesionPromoter
        cfg.Tiers.Add(New PrecedenceTier With {
        .Name = "3 AdhesionPromoter",
        .OpTypes = New List(Of String) From {
            "AdhesionPromoter"
        }
    })

        ' 4 WetInstall + DryInstall
        cfg.Tiers.Add(New PrecedenceTier With {
        .Name = "4 WetInstall + DryInstall",
        .OpTypes = New List(Of String) From {
            "WetInstall",
            "DryInstall"
        }
    })

        ' 5 FaySeal + Fay&FilletSeal
        cfg.Tiers.Add(New PrecedenceTier With {
        .Name = "5 FaySeal + Fay&FilletSeal",
        .OpTypes = New List(Of String) From {
            "FaySeal",
            "Fay&FilletSeal"
        }
    })

        ' 6 FilletSeal
        cfg.Tiers.Add(New PrecedenceTier With {
        .Name = "6 FilletSeal",
        .OpTypes = New List(Of String) From {
            "FilletSeal"
        }
    })

        ' 7 Overcoat
        cfg.Tiers.Add(New PrecedenceTier With {
        .Name = "7 Overcoat",
        .OpTypes = New List(Of String) From {
            "Overcoat"
        }
    })

        ' 8 TouchUp
        cfg.Tiers.Add(New PrecedenceTier With {
        .Name = "8 TouchUp",
        .OpTypes = New List(Of String) From {
            "TouchUp"
        }
    })

        ' 11 EBPrep
        cfg.Tiers.Add(New PrecedenceTier With {
        .Name = "11 EBPrep",
        .OpTypes = New List(Of String) From {
            "EBPrep"
        }
    })

        ' 12 ElectricalBond
        cfg.Tiers.Add(New PrecedenceTier With {
        .Name = "12 ElectricalBond",
        .OpTypes = New List(Of String) From {
            "ElectricalBond"
        }
    })

        ' 13 EBTouchUp
        cfg.Tiers.Add(New PrecedenceTier With {
        .Name = "13 EBTouchUp",
        .OpTypes = New List(Of String) From {
            "EBTouchUp"
        }
    })

        ' Special behavior used by the sequencer:
        ' AdhesionPromoter must be before the FIRST sealant operation present in the plan
        cfg.AdhesionPromoterOpType = "AdhesionPromoter"

        ' Sealant operations considered by "first sealant op" logic
        cfg.SealantOpTypes = New List(Of String) From {
        "FaySeal",
        "Fay&FilletSeal",
        "FilletSeal"
    }

        Return cfg
    End Function
End Class
