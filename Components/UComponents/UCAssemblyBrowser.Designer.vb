<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCAssemblyBrowser
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UCAssemblyBrowser))
        Me.lvIndexes = New System.Windows.Forms.ListView
        Me.ColumnHeader6 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader7 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader8 = New System.Windows.Forms.ColumnHeader
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.imgFlags = New System.Windows.Forms.ImageList(Me.components)
        Me.SuspendLayout()
        '
        'lvIndexes
        '
        Me.lvIndexes.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8})
        Me.lvIndexes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvIndexes.FullRowSelect = True
        Me.lvIndexes.GridLines = True
        Me.lvIndexes.HideSelection = False
        Me.lvIndexes.Location = New System.Drawing.Point(0, 0)
        Me.lvIndexes.Name = "lvIndexes"
        Me.lvIndexes.Size = New System.Drawing.Size(415, 202)
        Me.lvIndexes.TabIndex = 0
        Me.lvIndexes.UseCompatibleStateImageBehavior = False
        Me.lvIndexes.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Name"
        Me.ColumnHeader6.Width = 140
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Description"
        Me.ColumnHeader7.Width = 193
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Author"
        Me.ColumnHeader8.Width = 77
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "ok")
        Me.ImageList1.Images.SetKeyName(1, "error")
        '
        'imgFlags
        '
        Me.imgFlags.ImageStream = CType(resources.GetObject("imgFlags.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgFlags.TransparentColor = System.Drawing.Color.Transparent
        Me.imgFlags.Images.SetKeyName(0, "ad.png")
        Me.imgFlags.Images.SetKeyName(1, "ar.png")
        Me.imgFlags.Images.SetKeyName(2, "af.png")
        Me.imgFlags.Images.SetKeyName(3, "ag.png")
        Me.imgFlags.Images.SetKeyName(4, "ai.png")
        Me.imgFlags.Images.SetKeyName(5, "al.png")
        Me.imgFlags.Images.SetKeyName(6, "am.png")
        Me.imgFlags.Images.SetKeyName(7, "an.png")
        Me.imgFlags.Images.SetKeyName(8, "ao.png")
        Me.imgFlags.Images.SetKeyName(9, "as.png")
        Me.imgFlags.Images.SetKeyName(10, "at.png")
        Me.imgFlags.Images.SetKeyName(11, "au.png")
        Me.imgFlags.Images.SetKeyName(12, "aw.png")
        Me.imgFlags.Images.SetKeyName(13, "ax.png")
        Me.imgFlags.Images.SetKeyName(14, "az.png")
        Me.imgFlags.Images.SetKeyName(15, "ba.png")
        Me.imgFlags.Images.SetKeyName(16, "bb.png")
        Me.imgFlags.Images.SetKeyName(17, "bd.png")
        Me.imgFlags.Images.SetKeyName(18, "be.png")
        Me.imgFlags.Images.SetKeyName(19, "bf.png")
        Me.imgFlags.Images.SetKeyName(20, "bg.png")
        Me.imgFlags.Images.SetKeyName(21, "bh.png")
        Me.imgFlags.Images.SetKeyName(22, "bi.png")
        Me.imgFlags.Images.SetKeyName(23, "bj.png")
        Me.imgFlags.Images.SetKeyName(24, "bm.png")
        Me.imgFlags.Images.SetKeyName(25, "bn.png")
        Me.imgFlags.Images.SetKeyName(26, "bo.png")
        Me.imgFlags.Images.SetKeyName(27, "br.png")
        Me.imgFlags.Images.SetKeyName(28, "bs.png")
        Me.imgFlags.Images.SetKeyName(29, "bt.png")
        Me.imgFlags.Images.SetKeyName(30, "bv.png")
        Me.imgFlags.Images.SetKeyName(31, "bw.png")
        Me.imgFlags.Images.SetKeyName(32, "by.png")
        Me.imgFlags.Images.SetKeyName(33, "bz.png")
        Me.imgFlags.Images.SetKeyName(34, "ca.png")
        Me.imgFlags.Images.SetKeyName(35, "catalonia.png")
        Me.imgFlags.Images.SetKeyName(36, "cc.png")
        Me.imgFlags.Images.SetKeyName(37, "cd.png")
        Me.imgFlags.Images.SetKeyName(38, "cf.png")
        Me.imgFlags.Images.SetKeyName(39, "cg.png")
        Me.imgFlags.Images.SetKeyName(40, "ci.png")
        Me.imgFlags.Images.SetKeyName(41, "ck.png")
        Me.imgFlags.Images.SetKeyName(42, "cl.png")
        Me.imgFlags.Images.SetKeyName(43, "cm.png")
        Me.imgFlags.Images.SetKeyName(44, "cn.png")
        Me.imgFlags.Images.SetKeyName(45, "co.png")
        Me.imgFlags.Images.SetKeyName(46, "cr.png")
        Me.imgFlags.Images.SetKeyName(47, "cs.png")
        Me.imgFlags.Images.SetKeyName(48, "cu.png")
        Me.imgFlags.Images.SetKeyName(49, "cv.png")
        Me.imgFlags.Images.SetKeyName(50, "cx.png")
        Me.imgFlags.Images.SetKeyName(51, "cy.png")
        Me.imgFlags.Images.SetKeyName(52, "cz.png")
        Me.imgFlags.Images.SetKeyName(53, "de.png")
        Me.imgFlags.Images.SetKeyName(54, "dj.png")
        Me.imgFlags.Images.SetKeyName(55, "dk.png")
        Me.imgFlags.Images.SetKeyName(56, "dm.png")
        Me.imgFlags.Images.SetKeyName(57, "do.png")
        Me.imgFlags.Images.SetKeyName(58, "dz.png")
        Me.imgFlags.Images.SetKeyName(59, "ec.png")
        Me.imgFlags.Images.SetKeyName(60, "ee.png")
        Me.imgFlags.Images.SetKeyName(61, "eg.png")
        Me.imgFlags.Images.SetKeyName(62, "eh.png")
        Me.imgFlags.Images.SetKeyName(63, "england.png")
        Me.imgFlags.Images.SetKeyName(64, "er.png")
        Me.imgFlags.Images.SetKeyName(65, "es.png")
        Me.imgFlags.Images.SetKeyName(66, "et.png")
        Me.imgFlags.Images.SetKeyName(67, "europeanunion.png")
        Me.imgFlags.Images.SetKeyName(68, "fam.png")
        Me.imgFlags.Images.SetKeyName(69, "fi.png")
        Me.imgFlags.Images.SetKeyName(70, "fj.png")
        Me.imgFlags.Images.SetKeyName(71, "fk.png")
        Me.imgFlags.Images.SetKeyName(72, "fm.png")
        Me.imgFlags.Images.SetKeyName(73, "fo.png")
        Me.imgFlags.Images.SetKeyName(74, "fr.png")
        Me.imgFlags.Images.SetKeyName(75, "ga.png")
        Me.imgFlags.Images.SetKeyName(76, "en.png")
        Me.imgFlags.Images.SetKeyName(77, "gd.png")
        Me.imgFlags.Images.SetKeyName(78, "ge.png")
        Me.imgFlags.Images.SetKeyName(79, "gf.png")
        Me.imgFlags.Images.SetKeyName(80, "gh.png")
        Me.imgFlags.Images.SetKeyName(81, "gi.png")
        Me.imgFlags.Images.SetKeyName(82, "gl.png")
        Me.imgFlags.Images.SetKeyName(83, "gm.png")
        Me.imgFlags.Images.SetKeyName(84, "gn.png")
        Me.imgFlags.Images.SetKeyName(85, "gp.png")
        Me.imgFlags.Images.SetKeyName(86, "gq.png")
        Me.imgFlags.Images.SetKeyName(87, "gr.png")
        Me.imgFlags.Images.SetKeyName(88, "gs.png")
        Me.imgFlags.Images.SetKeyName(89, "gt.png")
        Me.imgFlags.Images.SetKeyName(90, "gu.png")
        Me.imgFlags.Images.SetKeyName(91, "gw.png")
        Me.imgFlags.Images.SetKeyName(92, "gy.png")
        Me.imgFlags.Images.SetKeyName(93, "hk.png")
        Me.imgFlags.Images.SetKeyName(94, "hm.png")
        Me.imgFlags.Images.SetKeyName(95, "hn.png")
        Me.imgFlags.Images.SetKeyName(96, "hr.png")
        Me.imgFlags.Images.SetKeyName(97, "ht.png")
        Me.imgFlags.Images.SetKeyName(98, "hu.png")
        Me.imgFlags.Images.SetKeyName(99, "ch.png")
        Me.imgFlags.Images.SetKeyName(100, "id.png")
        Me.imgFlags.Images.SetKeyName(101, "ie.png")
        Me.imgFlags.Images.SetKeyName(102, "il.png")
        Me.imgFlags.Images.SetKeyName(103, "in.png")
        Me.imgFlags.Images.SetKeyName(104, "io.png")
        Me.imgFlags.Images.SetKeyName(105, "iq.png")
        Me.imgFlags.Images.SetKeyName(106, "ir.png")
        Me.imgFlags.Images.SetKeyName(107, "is.png")
        Me.imgFlags.Images.SetKeyName(108, "it.png")
        Me.imgFlags.Images.SetKeyName(109, "jm.png")
        Me.imgFlags.Images.SetKeyName(110, "jo.png")
        Me.imgFlags.Images.SetKeyName(111, "jp.png")
        Me.imgFlags.Images.SetKeyName(112, "ke.png")
        Me.imgFlags.Images.SetKeyName(113, "kg.png")
        Me.imgFlags.Images.SetKeyName(114, "kh.png")
        Me.imgFlags.Images.SetKeyName(115, "ki.png")
        Me.imgFlags.Images.SetKeyName(116, "km.png")
        Me.imgFlags.Images.SetKeyName(117, "kn.png")
        Me.imgFlags.Images.SetKeyName(118, "kp.png")
        Me.imgFlags.Images.SetKeyName(119, "kr.png")
        Me.imgFlags.Images.SetKeyName(120, "kw.png")
        Me.imgFlags.Images.SetKeyName(121, "ky.png")
        Me.imgFlags.Images.SetKeyName(122, "kz.png")
        Me.imgFlags.Images.SetKeyName(123, "la.png")
        Me.imgFlags.Images.SetKeyName(124, "lb.png")
        Me.imgFlags.Images.SetKeyName(125, "lc.png")
        Me.imgFlags.Images.SetKeyName(126, "li.png")
        Me.imgFlags.Images.SetKeyName(127, "lk.png")
        Me.imgFlags.Images.SetKeyName(128, "lr.png")
        Me.imgFlags.Images.SetKeyName(129, "ls.png")
        Me.imgFlags.Images.SetKeyName(130, "lt.png")
        Me.imgFlags.Images.SetKeyName(131, "lu.png")
        Me.imgFlags.Images.SetKeyName(132, "lv.png")
        Me.imgFlags.Images.SetKeyName(133, "ly.png")
        Me.imgFlags.Images.SetKeyName(134, "ma.png")
        Me.imgFlags.Images.SetKeyName(135, "mc.png")
        Me.imgFlags.Images.SetKeyName(136, "md.png")
        Me.imgFlags.Images.SetKeyName(137, "me.png")
        Me.imgFlags.Images.SetKeyName(138, "mg.png")
        Me.imgFlags.Images.SetKeyName(139, "mh.png")
        Me.imgFlags.Images.SetKeyName(140, "mk.png")
        Me.imgFlags.Images.SetKeyName(141, "ml.png")
        Me.imgFlags.Images.SetKeyName(142, "mm.png")
        Me.imgFlags.Images.SetKeyName(143, "mn.png")
        Me.imgFlags.Images.SetKeyName(144, "mo.png")
        Me.imgFlags.Images.SetKeyName(145, "mp.png")
        Me.imgFlags.Images.SetKeyName(146, "mq.png")
        Me.imgFlags.Images.SetKeyName(147, "mr.png")
        Me.imgFlags.Images.SetKeyName(148, "ms.png")
        Me.imgFlags.Images.SetKeyName(149, "mt.png")
        Me.imgFlags.Images.SetKeyName(150, "mu.png")
        Me.imgFlags.Images.SetKeyName(151, "mv.png")
        Me.imgFlags.Images.SetKeyName(152, "mw.png")
        Me.imgFlags.Images.SetKeyName(153, "mx.png")
        Me.imgFlags.Images.SetKeyName(154, "my.png")
        Me.imgFlags.Images.SetKeyName(155, "mz.png")
        Me.imgFlags.Images.SetKeyName(156, "na.png")
        Me.imgFlags.Images.SetKeyName(157, "nc.png")
        Me.imgFlags.Images.SetKeyName(158, "ne.png")
        Me.imgFlags.Images.SetKeyName(159, "nf.png")
        Me.imgFlags.Images.SetKeyName(160, "ng.png")
        Me.imgFlags.Images.SetKeyName(161, "ni.png")
        Me.imgFlags.Images.SetKeyName(162, "nl.png")
        Me.imgFlags.Images.SetKeyName(163, "no.png")
        Me.imgFlags.Images.SetKeyName(164, "np.png")
        Me.imgFlags.Images.SetKeyName(165, "nr.png")
        Me.imgFlags.Images.SetKeyName(166, "nu.png")
        Me.imgFlags.Images.SetKeyName(167, "nz.png")
        Me.imgFlags.Images.SetKeyName(168, "om.png")
        Me.imgFlags.Images.SetKeyName(169, "pa.png")
        Me.imgFlags.Images.SetKeyName(170, "pe.png")
        Me.imgFlags.Images.SetKeyName(171, "pf.png")
        Me.imgFlags.Images.SetKeyName(172, "pg.png")
        Me.imgFlags.Images.SetKeyName(173, "ph.png")
        Me.imgFlags.Images.SetKeyName(174, "pk.png")
        Me.imgFlags.Images.SetKeyName(175, "pl.png")
        Me.imgFlags.Images.SetKeyName(176, "pm.png")
        Me.imgFlags.Images.SetKeyName(177, "pn.png")
        Me.imgFlags.Images.SetKeyName(178, "pr.png")
        Me.imgFlags.Images.SetKeyName(179, "ps.png")
        Me.imgFlags.Images.SetKeyName(180, "pt.png")
        Me.imgFlags.Images.SetKeyName(181, "pw.png")
        Me.imgFlags.Images.SetKeyName(182, "py.png")
        Me.imgFlags.Images.SetKeyName(183, "qa.png")
        Me.imgFlags.Images.SetKeyName(184, "re.png")
        Me.imgFlags.Images.SetKeyName(185, "ro.png")
        Me.imgFlags.Images.SetKeyName(186, "rs.png")
        Me.imgFlags.Images.SetKeyName(187, "ru.png")
        Me.imgFlags.Images.SetKeyName(188, "rw.png")
        Me.imgFlags.Images.SetKeyName(189, "sa.png")
        Me.imgFlags.Images.SetKeyName(190, "sb.png")
        Me.imgFlags.Images.SetKeyName(191, "sc.png")
        Me.imgFlags.Images.SetKeyName(192, "scotland.png")
        Me.imgFlags.Images.SetKeyName(193, "sd.png")
        Me.imgFlags.Images.SetKeyName(194, "se.png")
        Me.imgFlags.Images.SetKeyName(195, "sg.png")
        Me.imgFlags.Images.SetKeyName(196, "sh.png")
        Me.imgFlags.Images.SetKeyName(197, "si.png")
        Me.imgFlags.Images.SetKeyName(198, "sj.png")
        Me.imgFlags.Images.SetKeyName(199, "sk.png")
        Me.imgFlags.Images.SetKeyName(200, "sl.png")
        Me.imgFlags.Images.SetKeyName(201, "sm.png")
        Me.imgFlags.Images.SetKeyName(202, "sn.png")
        Me.imgFlags.Images.SetKeyName(203, "so.png")
        Me.imgFlags.Images.SetKeyName(204, "sr.png")
        Me.imgFlags.Images.SetKeyName(205, "st.png")
        Me.imgFlags.Images.SetKeyName(206, "sv.png")
        Me.imgFlags.Images.SetKeyName(207, "sy.png")
        Me.imgFlags.Images.SetKeyName(208, "sz.png")
        Me.imgFlags.Images.SetKeyName(209, "tc.png")
        Me.imgFlags.Images.SetKeyName(210, "td.png")
        Me.imgFlags.Images.SetKeyName(211, "tf.png")
        Me.imgFlags.Images.SetKeyName(212, "tg.png")
        Me.imgFlags.Images.SetKeyName(213, "th.png")
        Me.imgFlags.Images.SetKeyName(214, "tj.png")
        Me.imgFlags.Images.SetKeyName(215, "tk.png")
        Me.imgFlags.Images.SetKeyName(216, "tl.png")
        Me.imgFlags.Images.SetKeyName(217, "tm.png")
        Me.imgFlags.Images.SetKeyName(218, "tn.png")
        Me.imgFlags.Images.SetKeyName(219, "to.png")
        Me.imgFlags.Images.SetKeyName(220, "tr.png")
        Me.imgFlags.Images.SetKeyName(221, "tt.png")
        Me.imgFlags.Images.SetKeyName(222, "tv.png")
        Me.imgFlags.Images.SetKeyName(223, "tw.png")
        Me.imgFlags.Images.SetKeyName(224, "tz.png")
        Me.imgFlags.Images.SetKeyName(225, "ua.png")
        Me.imgFlags.Images.SetKeyName(226, "ug.png")
        Me.imgFlags.Images.SetKeyName(227, "um.png")
        Me.imgFlags.Images.SetKeyName(228, "us.png")
        Me.imgFlags.Images.SetKeyName(229, "uy.png")
        Me.imgFlags.Images.SetKeyName(230, "uz.png")
        Me.imgFlags.Images.SetKeyName(231, "va.png")
        Me.imgFlags.Images.SetKeyName(232, "vc.png")
        Me.imgFlags.Images.SetKeyName(233, "ve.png")
        Me.imgFlags.Images.SetKeyName(234, "vg.png")
        Me.imgFlags.Images.SetKeyName(235, "vi.png")
        Me.imgFlags.Images.SetKeyName(236, "vn.png")
        Me.imgFlags.Images.SetKeyName(237, "vu.png")
        Me.imgFlags.Images.SetKeyName(238, "wales.png")
        Me.imgFlags.Images.SetKeyName(239, "wf.png")
        Me.imgFlags.Images.SetKeyName(240, "ws.png")
        Me.imgFlags.Images.SetKeyName(241, "ye.png")
        Me.imgFlags.Images.SetKeyName(242, "yt.png")
        Me.imgFlags.Images.SetKeyName(243, "za.png")
        Me.imgFlags.Images.SetKeyName(244, "zm.png")
        Me.imgFlags.Images.SetKeyName(245, "zw.png")
        Me.imgFlags.Images.SetKeyName(246, "[dna].png")
        Me.imgFlags.Images.SetKeyName(247, "[ GENERIC ].png")
        '
        'UCAssemblyBrowser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lvIndexes)
        Me.DoubleBuffered = True
        Me.Name = "UCAssemblyBrowser"
        Me.Size = New System.Drawing.Size(415, 202)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lvIndexes As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents imgFlags As System.Windows.Forms.ImageList

End Class
