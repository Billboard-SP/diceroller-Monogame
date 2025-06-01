using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Text;

namespace dicerollerMonogame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        SpriteBatch spriteBatch;
        SpriteFont font;

        DamageRoll roll;
        string summary = "Press SPACE to roll damage. \nPress R to reset.";

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            SetupRoll();
        }

        private void SetupRoll()
        {
            roll = new DamageRoll(2, 6, 3, "slashing");
            roll.AddMiscDamage(2, 8, "radiant");
            roll.AddMiscDamage(1, 4, "thunder");
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("DefaultFont");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.Space))
            {
                roll.RollDamage();
                summary = BuildSummary(roll);
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        private string BuildSummary(DamageRoll roll)
        {
            Dictionary<string, int> breakdown = roll.GetDamageBreakdown();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Damage Breakdown:");
            foreach (var entry in breakdown)
            {
                sb.AppendLine($"- {entry.Key}: {entry.Value}");
            }
            sb.AppendLine($"Total Damage: {roll.GetTotalDamage()}");
            return sb.ToString();
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            spriteBatch.DrawString(font, summary, new Vector2(20, 20), Color.White);
            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
