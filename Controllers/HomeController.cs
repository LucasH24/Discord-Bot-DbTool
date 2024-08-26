using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Drawing2D;

public class HomeController : Controller
{
  private DataContext _dataContext;
  public HomeController(DataContext db) => _dataContext = db;
  public ActionResult Index() => View();

  [HttpGet]
  public IActionResult GetMiwPlayers()
  {
    var miwPlayers = _dataContext.MiwPlayers.ToList();
    return Json(miwPlayers);
  }


  [HttpPost]
  public ActionResult Index(string[] player)
  {
    MiwPlayer miwPlayer = _dataContext.MiwPlayers.FirstOrDefault(m => m.UUID == player[0]);

    if (miwPlayer != null)
    {
      miwPlayer.Username = player[1];
      miwPlayer.Wins = Convert.ToInt32(player[2]);
      miwPlayer.Kills = Convert.ToInt32(player[3]);
      miwPlayer.Finals = Convert.ToInt32(player[4]);
      miwPlayer.WitherKills = Convert.ToInt32(player[5]);
      miwPlayer.WitherDamage = Convert.ToInt32(player[6]);
      miwPlayer.Deaths = Convert.ToInt32(player[7]);
      miwPlayer.ArrowsHit = Convert.ToInt32(player[8]);
      miwPlayer.ArrowsShot = Convert.ToInt32(player[9]);
      miwPlayer.KD = Math.Round((decimal)miwPlayer.Kills / miwPlayer.Deaths, 2);
      miwPlayer.FKD = Math.Round((decimal)miwPlayer.Finals / miwPlayer.Deaths, 2);
      miwPlayer.TKD = Math.Round((decimal)(miwPlayer.Kills + miwPlayer.Finals) / miwPlayer.Deaths, 2);
      miwPlayer.WDD = Math.Round((decimal)miwPlayer.WitherDamage / miwPlayer.Deaths, 2);
      miwPlayer.WKD = Math.Round((decimal)miwPlayer.WitherKills / miwPlayer.Deaths, 2);
      miwPlayer.AA = Math.Round((decimal)miwPlayer.ArrowsHit / miwPlayer.ArrowsShot, 2);
      miwPlayer.RATE = Math.Round((miwPlayer.KD/(decimal)1.44)+(miwPlayer.FKD/(decimal)0.64)+(miwPlayer.TKD/(decimal)2.08)+(miwPlayer.WDD/(decimal)12.5)+(miwPlayer.WKD/(decimal)0.24), 2);
      miwPlayer.KPW = Math.Round((decimal)miwPlayer.Kills / miwPlayer.Wins, 2);
      miwPlayer.FPW = Math.Round((decimal)miwPlayer.Finals / miwPlayer.Wins, 2);
      miwPlayer.TKPW = Math.Round((decimal)(miwPlayer.Kills + miwPlayer.Finals) / miwPlayer.Wins, 2);
      miwPlayer.WDPW = Math.Round((decimal)miwPlayer.WitherDamage / miwPlayer.Wins, 2);
      miwPlayer.WKPW = Math.Round((decimal)miwPlayer.WitherKills / miwPlayer.Wins, 2);
      miwPlayer.DPW = Math.Round((decimal)miwPlayer.Deaths / miwPlayer.Wins, 2);
      miwPlayer.SPW = Math.Round((miwPlayer.KPW/(decimal)7.27)+(miwPlayer.FPW/(decimal)3.08)+(miwPlayer.DPW/(decimal)5.58)+(miwPlayer.WDPW/(decimal)46.63)+(miwPlayer.WKPW/(decimal)0.9), 2);
    }
    _dataContext.SaveChanges();
    _dataContext.Dispose();
    return View();
  }

  [HttpPost]
  public ActionResult UpdatePlayerRanking(string[] player)
  {
    
    MiwPlayer miwPlayer = _dataContext.MiwPlayers.FirstOrDefault(m => m.UUID == player[0]);

    if (miwPlayer != null)
    {
      miwPlayer.RankWins = Convert.ToInt32(player[1]);
      miwPlayer.RankKills = Convert.ToInt32(player[2]);
      miwPlayer.RankFinals = Convert.ToInt32(player[3]);
      miwPlayer.RankWitherDamage = Convert.ToInt32(player[4]);
      miwPlayer.RankWitherKills = Convert.ToInt32(player[5]);
      miwPlayer.RankDeaths = Convert.ToInt32(player[6]);
      miwPlayer.RankArrowsHit = Convert.ToInt32(player[7]);
      miwPlayer.RankArrowsShot = Convert.ToInt32(player[8]);
      miwPlayer.RankKD = Convert.ToInt32(player[9]);
      miwPlayer.RankFKD = Convert.ToInt32(player[10]);
      miwPlayer.RankTKD = Convert.ToInt32(player[11]);
      miwPlayer.RankWDD = Convert.ToInt32(player[12]);
      miwPlayer.RankWKD = Convert.ToInt32(player[13]);
      miwPlayer.RankAA = Convert.ToInt32(player[14]);
      miwPlayer.RankRATE = Convert.ToInt32(player[15]);
      miwPlayer.RankKPW = Convert.ToInt32(player[16]);
      miwPlayer.RankFPW = Convert.ToInt32(player[17]);
      miwPlayer.RankTKPW = Convert.ToInt32(player[18]);
      miwPlayer.RankWDPW = Convert.ToInt32(player[19]);
      miwPlayer.RankWKPW = Convert.ToInt32(player[20]);
      miwPlayer.RankDPW = Convert.ToInt32(player[21]);
      miwPlayer.RankSPW = Convert.ToInt32(player[22]);
    }
    
    _dataContext.SaveChanges();
    _dataContext.Dispose();
    return RedirectToAction("Index", "Home");
  }
}
