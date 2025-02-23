using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Projectiles;

public class DemonWaveProj : ModProjectile
{
	private int KB = 7;

	private int dust_num = 162;

	private int dust_num2 = 6;

	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Sand Proj2");
		ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
		ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
	}

	public override void SetDefaults()
	{
		Projectile.width = 12;
		Projectile.height = 12;
		Projectile.aiStyle = 0;
		Projectile.DamageType = DamageClass.Magic;
		Projectile.friendly = true;
		Projectile.hostile = false;
		Projectile.penetrate = 1;
		Projectile.timeLeft = 600;
		Projectile.light = 0.4f;
		Projectile.ignoreWater = true;
		Projectile.tileCollide = true;
		Projectile.extraUpdates = 1;
		Projectile.knockBack = 7f;
	}

	public override bool OnTileCollide(Vector2 oldVelocity)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		SoundEngine.PlaySound(SoundID.Dig, (Vector2?)Projectile.position);
		return true;
	}

	public override void AI()
	{
		this.KB = 0;
		int dust2 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 173);
		Main.dust[dust2].velocity.Y *= 0f;
	}

	public override void OnKill(int timeLeft)
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		Player p = Main.player[Projectile.owner];
		SoundEngine.PlaySound(SoundID.NPCHit21, (Vector2?)Projectile.position);
		Projectile.NewProjectile(Projectile.GetSource_Death(), new Vector2(Projectile.position.X + 6f, Projectile.position.Y + 6f), new Vector2(0f, 0f), Mod.Find<ModProjectile>("DemonWave").Type, Projectile.damage, (float)this.KB, p.whoAmI, 0f, 0f);
	}
}
