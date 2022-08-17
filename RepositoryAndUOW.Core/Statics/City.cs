using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryAndUOW.Core.Statics;

public enum City
{
    [Description("دمشق")]
    Damascus,
    [Description("حلب")]
    Aleppo,
    [Description("حمص")]
    Homs,
    [Description("حماه")]
    Hamah,
    [Description("إدلب")]
    Idlib,
    [Description("طرطوس")]
    Tartous,
    [Description("اللاذقية")]
    Lattakia,
    [Description("دير الزور")]
    DerEzzor,
    [Description("البوكمال")]
    Bukamal,
    [Description("الحسكة")]
    Hasakah,
    [Description("القنيطرة")]
    Quneitra,
    [Description("الرقة")]
    Raqqah,
    [Description("درعا")]
    Daraa,
    [Description("السويداء")]
    Sewedaa,
    [Description("خارج سوريا")]
    OutSide,
}
