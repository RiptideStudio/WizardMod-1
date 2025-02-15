using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Projectiles;

public class DeathEaterSkullPlayer : ModProjectile
{
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
		DrawOffsetX = -16;
		DrawOriginOffsetY = -12;
		Projectile.timeLeft = 250;
		Projectile.light = 0f;
		Projectile.ignoreWater = true;
		Projectile.tileCollide = true;
		Projectile.extraUpdates = 1;
	}

	public override void AI()
	{
		Player player = Main.LocalPlayer;
		Projectile.aiStyle = 1;
		Projectile.velocity = player.velocity;
		Projectile.position = player.position;
	}

	public virtual void OnHitNPC(NPC target, int damage, float knockback, bool crit)
	{
		target.AddBuff(Mod.Find<ModBuff>("DarknessDebuff").Type, 120);
		Player p = Main.player[Projectile.owner];
		_ = Projectile.Center;
		float projectilespeedY = 0f;
		float projectileknockBack = 3f;
		projectilespeedY = new Vector2(5f, projectilespeedY).RotatedByRandom(MathHelper.ToRadians(360f)).Y;
		Projectile.NewProjectile(Projectile.GetSource_Death(), Projectile.position, new Vector2(0f, 0f), Mod.Find<ModProjectile>("ShadowExplosion").Type, Projectile.damage, projectileknockBack, p.whoAmI, 0f, 0f);
	}
}
