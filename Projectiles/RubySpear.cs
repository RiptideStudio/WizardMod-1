using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Projectiles;

public class RubySpear : ModProjectile
{
	public float movementFactor
	{
		get
		{
			return Projectile.ai[0] - 0.5f;
		}
		set
		{
			Projectile.ai[0] = value;
		}
	}

	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Sapphire Beam");
		ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
		ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
	}

	public override void SetDefaults()
	{
		Projectile.width = 9;
		Projectile.height = 18;
		Projectile.aiStyle = 19;
		Projectile.penetrate = -1;
		Projectile.scale = 1.3f;
		Projectile.alpha = 0;
		Projectile.hide = true;
		Projectile.ownerHitCheck = true;
		Projectile.DamageType = DamageClass.Melee;
		Projectile.tileCollide = false;
		Projectile.friendly = true;
		Projectile.timeLeft = 60;
	}

	public override void AI()
	{
		Player projOwner = Main.player[Projectile.owner];
		Vector2 ownerMountedCenter = projOwner.RotatedRelativePoint(projOwner.MountedCenter, reverseRotation: true);
		Projectile.direction = projOwner.direction;
		projOwner.heldProj = Projectile.whoAmI;
		projOwner.itemTime = projOwner.itemAnimation;
		Projectile.position.X = ownerMountedCenter.X - (float)(Projectile.width / 2);
		Projectile.position.Y = ownerMountedCenter.Y - (float)(Projectile.height / 2);
		if (!projOwner.frozen)
		{
			if (this.movementFactor == 0f)
			{
				this.movementFactor = 1.5f;
				Projectile.netUpdate = true;
			}
			if (projOwner.itemAnimation < projOwner.itemAnimationMax / 3)
			{
				this.movementFactor -= 2.4f;
			}
			else
			{
				this.movementFactor += 2.1f;
			}
		}
		Projectile.position += Projectile.velocity * this.movementFactor;
		if (projOwner.itemAnimation == 0)
		{
			Projectile.Kill();
		}
		Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(135f);
		if (Projectile.spriteDirection == -1)
		{
			Projectile.rotation -= MathHelper.ToRadians(90f);
		}
	}
}
