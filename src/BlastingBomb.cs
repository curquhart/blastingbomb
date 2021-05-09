using Vintagestory.API.Common;
using Vintagestory.API.Config;

[assembly: ModInfo( "Bomb" )]

namespace Bomb
{
	public class BlastingBomb : ModSystem
	{
		public override void Start(ICoreAPI api)
		{
			// override language - xxx - find a better way to do this.
			Lang.Inst.LangEntries["game:block-oreblastingbomb"] = Lang.Get("blastingbomb:block-blastingbomb");
			Lang.Inst.LangEntries["game:blockdesc-oreblastingbomb"] = Lang.Get("blastingbomb:blockdesc-blastingbomb");
			Patch.Init();
		}
	}
}
