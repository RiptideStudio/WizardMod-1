using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;

namespace WizardMod.Projectiles;

public class FiendfyreLaser : ModProjectile
{
	private const float MAX_CHARGE = 70f;

	private const float MOVE_DISTANCE = 60f;

	private bool scaled = true;

	private int time;

	public float Distance
	{
		get
		{
			return Projectile.ai[0];
		}
		set
		{
			Projectile.ai[0] = value;
		}
	}

	public float Charge
	{
		get
		{
			return Projectile.localAI[0];
		}
		set
		{
			Projectile.localAI[0] = value;
		}
	}

	public bool IsAtMaxCharge => this.Charge == 70f;

	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Sand Proj2");
		ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
		ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
	}

	public override void SetDefaults()
	{
		Projectile.width = 10;
		Projectile.height = 10;
		Projectile.friendly = true;
		Projectile.penetrate = -1;
		Projectile.tileCollide = false;
		Projectile.DamageType = DamageClass.Magic;
		Projectile.scale = 0.25f;
		Projectile.hide = true;
	}

	public void DrawLaser(SpriteBatch spriteBatch, Texture2D texture, Vector2 start, Vector2 unit, float step, int damage, float rotation = 0f, float scale = 1f, float maxDist = 2000f, Color color = default(Color), int transDist = 50)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		this.time++;
		if (this.time % 10 == 0)
		{
			SoundEngine.PlaySound(SoundID.Item34, (Vector2?)Projectile.position);
		}
		float r = unit.ToRotation() + rotation;
		if (Projectile.scale < 0.1f && !this.scaled)
		{
			this.scaled = true;
		}
		if (this.scaled)
		{
			Projectile.scale += 0.01f;
		}
		else
		{
			Projectile.scale -= 0.01f;
		}
		if (Projectile.scale >= 0.2f && this.scaled)
		{
			this.scaled = false;
		}
		for (float i = transDist; i <= this.Distance; i += step)
		{
			Color c = Color.Yellow;
			float num1 = Projectile.velocity.ToRotation() + ((Main.rand.Next(2) == 1) ? (-1f) : 1f) * 1.57f;
			float num2 = (float)(Main.rand.NextDouble() * 0.800000011920929 + 1.0);
			new Vector2((float)Math.Cos((double)num1) * num2, (float)Math.Sin((double)num1) * num2);
			Vector2 muzzleOffset = new Vector2(-2f, 8f);
			Vector2 dustOffset = new Vector2(0f, 4f);
			if (Main.player[Projectile.owner].direction == -1)
			{
				muzzleOffset = new Vector2(-2f, -2f);
				dustOffset = new Vector2(0f, 16f);
			}
			Vector2 origin = start + i * unit - muzzleOffset;
			int dust2 = Dust.NewDust(origin - dustOffset, 0, 0, 6);
			Main.dust[dust2].noGravity = true;
			Main.dust[dust2].scale = (float)Main.rand.Next(150, 180) * 0.013f;
			Main.dust[dust2].velocity.Y *= -4f;
			spriteBatch.Draw(texture, origin - Main.screenPosition - muzzleOffset, new Rectangle(0, 0, 10, 10), (i < (float)transDist) ? Color.Transparent : c, r, new Vector2(14f, 13f), 1f + Projectile.scale, SpriteEffects.None, Projectile.alpha);
		}
		spriteBatch.Draw(texture, start + (this.Distance + step) * unit - Main.screenPosition, new Rectangle(0, 0, 10, 10), Color.White, r, new Vector2(14f, 13f), Projectile.scale, SpriteEffects.None, 0f);
	}

	public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
	{
		if (!this.IsAtMaxCharge)
		{
			return false;
		}
		Player player = Main.player[Projectile.owner];
		Vector2 unit = Projectile.velocity;
		float point = 0f;
		return Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), player.Center, player.Center + unit * this.Distance, 22f, ref point);
	}

	public virtual void OnHitNPC(NPC target, int damage, float knockback, bool crit)
	{
		target.immune[Projectile.owner] = 5;
		target.AddBuff(24, 240);
	}

	public override void AI()
	{
		Player player = Main.player[Projectile.owner];
		Projectile.position = player.Center + Projectile.velocity * 60f;
		Projectile.timeLeft = 2;
		this.UpdatePlayer(player);
		this.ChargeLaser(player);
		if (!(this.Charge < 70f))
		{
			this.SetLaserPosition(player);
			this.SpawnDusts(player);
			this.CastLights();
		}
	}

	private void SpawnDusts(Player player)
	{
		Vector2 unit = Projectile.velocity * -1f;
		Vector2 dustPos = player.Center + Projectile.velocity * this.Distance;
		for (int i = 0; i < 2; i++)
		{
			float num1 = Projectile.velocity.ToRotation() + ((Main.rand.Next(2) == 1) ? (-1f) : 1f) * 12.57f;
			float num2 = (float)(Main.rand.NextDouble() * 0.800000011920929 + 1.0);
			Vector2 dustVel = new Vector2((float)Math.Cos((double)num1) * num2, (float)Math.Sin((double)num1) * num2);
			Dust obj = Main.dust[Dust.NewDust(dustPos, 0, 0, 6, dustVel.X, dustVel.Y)];
			obj.noGravity = true;
			obj.scale = 1.2f;
		}
		if (Main.rand.NextBool(5))
		{
			Vector2 offset = Projectile.velocity.RotatedBy(1.5700000524520874) * ((float)Main.rand.NextDouble() - 0.5f) * Projectile.width;
			Dust dust = Main.dust[Dust.NewDust(dustPos + offset - Vector2.One * 4f, 8, 8, 6, 0f, 0f, 6, default(Color), 1.5f)];
			dust.velocity *= 7.5f;
			dust.velocity.Y = 0f - Math.Abs(dust.velocity.Y);
			unit = dustPos - Main.player[Projectile.owner].Center;
			unit.Normalize();
			dust = Main.dust[Dust.NewDust(Main.player[Projectile.owner].Center + 55f * unit, 8, 8, 6, 0f, 0f, 6, default(Color), 1.5f)];
			dust.velocity *= 7.5f;
			dust.velocity.Y = 0f - Math.Abs(dust.velocity.Y);
		}
	}

	private void SetLaserPosition(Player player)
	{
		this.Distance = 60f;
		while (this.Distance <= 2200f)
		{
			Vector2 start = player.Center + Projectile.velocity * this.Distance;
			if (!Collision.CanHit(player.Center, 1, 1, start, 1, 1))
			{
				this.Distance -= 5f;
				break;
			}
			this.Distance += 5f;
		}
	}

	private void ChargeLaser(Player player)
	{
		if (!player.channel)
		{
			Projectile.Kill();
			return;
		}
		if (Main.time % 10.0 < 1.0 && !player.CheckMana(player.inventory[player.selectedItem].mana, pay: true))
		{
			Projectile.Kill();
		}
		Vector2 offset = Projectile.velocity;
		Vector2 pos = player.Center + offset - new Vector2(-6f, 20f);
		offset *= 40f;
		pos = ((player.direction != 1) ? (player.Center + offset - new Vector2(26f, 16f)) : (player.Center + offset - new Vector2(-6f, 20f)));
		if (this.Charge < 70f)
		{
			this.Charge++;
		}
		int chargeFact = (int)(this.Charge / 20f);
		Vector2 dustVelocity = Vector2.UnitX * 18f;
		dustVelocity = dustVelocity.RotatedBy(Projectile.rotation - 1.57f);
		Vector2 spawnPos = Projectile.Center + dustVelocity;
		if (!this.IsAtMaxCharge)
		{
			for (int i = 0; i < chargeFact + 1; i++)
			{
				_ = spawnPos + ((float)Main.rand.NextDouble() * 6.28f).ToRotationVector2() * (12f - (float)(chargeFact * 2));
				Dust obj = Main.dust[Dust.NewDust(pos, 20, 20, 6, Projectile.velocity.X / 2f, Projectile.velocity.Y / 2f)];
				obj.velocity *= this.Charge / 10f;
				obj.noGravity = true;
				obj.scale = (float)Main.rand.Next(10 + (int)this.Charge / 3, 20 + (int)this.Charge / 3) * 0.05f;
			}
		}
	}

	private void UpdatePlayer(Player player)
	{
		if (Projectile.owner == Main.myPlayer)
		{
			Vector2 diff = Main.MouseWorld - player.Center;
			diff.Normalize();
			Projectile.velocity = diff;
			Projectile.direction = ((Main.MouseWorld.X > player.position.X) ? 1 : (-1));
			Projectile.netUpdate = true;
		}
		int dir = Projectile.direction;
		player.ChangeDir(dir);
		player.heldProj = Projectile.whoAmI;
		player.itemTime = 2;
		player.itemAnimation = 2;
		player.itemRotation = (float)Math.Atan2((double)(Projectile.velocity.Y * (float)dir), (double)(Projectile.velocity.X * (float)dir));
	}

	private void CastLights()
	{
		DelegateMethods.v3_1 = new Vector3(0.8f, 0.8f, 1f);
		Utils.PlotTileLine(Projectile.Center, Projectile.Center + Projectile.velocity * (this.Distance - 60f), 26f, DelegateMethods.CastLight);
	}

	public override bool ShouldUpdatePosition()
	{
		return false;
	}

	public override void CutTiles()
	{
		DelegateMethods.tilecut_0 = TileCuttingContext.AttackProjectile;
		Vector2 unit = Projectile.velocity;
		Utils.PlotTileLine(Projectile.Center, Projectile.Center + unit * this.Distance, (float)(Projectile.width + 16) * Projectile.scale, DelegateMethods.CutTiles);
	}
}
