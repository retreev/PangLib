using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO;
using System.Text;
using PangLib.IFF.Models.Data;
using System.Security.Cryptography;
using PangLib.IFF.Models.General;
using System.Threading;
using PangLib.IFF.Models.Flags;

namespace PangLib.IFF.Extensions
{
    /// <summary>
    /// Based in Acrisio SS Dev
    /// </summary>
    public class sIFFHandle
    {
        public IFFFile<Part> m_part;
        public IFFFile<Item> m_item;
        public IFFFile<SetItem> m_set_item;
        public IFFFile<Mascot> m_mascot;
        public IFFFile<Achievement> m_achievement;
        public IFFFile<Models.Data.CounterItem> m_counter_item;
        public IFFFile<QuestStuff> m_quest_stuff;
        public IFFFile<QuestItem> m_quest_item;
        public IFFFile<AuxPart> m_aux_part;
        public IFFFile<Ball> m_ball;
        public IFFFile<Caddie> m_caddie;
        public IFFFile<CaddieItem> m_caddie_item;
        public IFFFile<Card> m_card;
        public IFFFile<Character> m_character;
        public IFFFile<Club> m_club;
        public IFFFile<ClubSet> m_club_set;
        public IFFFile<Models.Data.ClubSetWorkShopLevelUpProb> m_club_set_work_shop_level_up_prob;
        public IFFFile<Models.Data.ClubSetWorkShopRankUpExp> m_club_set_work_shop_rank_exp;
        public IFFFile<Course> m_course;
        public IFFFile<Models.Data.CutinInformation> m_cutin_infomation;
        public IFFFile<Enchant> m_enchant;
        public IFFFile<Furniture> m_furniture;
        public IFFFile<HairStyle> m_hair_style;
        public IFFFile<Match> m_match;
        public IFFFile<Skin> m_skin;
        public IFFFile<Ability> m_ability;
        public IFFFile<Desc> m_desc;
        public IFFFile<Models.Data.GrandPrixAIOptionalData> m_grand_prix_ai_optinal_data;
        public IFFFile<Models.Data.GrandPrixConditionEquip> m_grand_prix_condition_equip;
        public IFFFile<GrandPrixData> m_grand_prix_data;
        public IFFFile<MemorialShopCoinItem> m_memorial_shop_coin_item;
        public IFFFile<Models.Data.ArtifactManaInfo> m_artifact_mana_info;
        public IFFFile<Models.Data.ErrorCodeInfo> m_error_code_info;
        public IFFFile<Models.Data.HoleCupDropItem> m_hole_cup_drop_item;
        public IFFFile<LevelUpPrizeItem> m_level_up_prize_item;
        public IFFFile<Models.Data.NonVisibleItemTable> m_non_visible_item_table;
        public IFFFile<Models.Data.PointShop> m_point_shop;
        public IFFFile<Models.Data.ShopLimitItem> m_shop_limit_item;
        public IFFFile<Models.Data.SpecialPrizeItem> m_special_prize_item;
        public IFFFile<Models.Data.SubscriptionItemTable> m_subscription_item_table;
        public IFFFile<SetEffectTable> m_set_effect_table;
        public IFFFile<TikiPointTable> m_tiki_point_table;
        public IFFFile<TikiRecipe> m_tiki_recipe;
        public IFFFile<TikiSpecialTable> m_tiki_special_table;
        public IFFFile<Models.Data.TimeLimitItem> m_time_limit_item;
        public IFFFile<Models.Data.AddonPart> m_addon_part;
        public IFFFile<CadieMagicBox> m_cadie_magic_box;
        public IFFFile<CadieMagicBoxRandom> m_cadie_magic_box_random;
        public IFFFile<Models.Data.CharacterMastery> m_character_mastery;
        public IFFFile<Models.Data.ClubSetWorkShopLevelUpLimit> m_club_set_work_shop_level_up_limit;
        public IFFFile<GrandPrixRankReward> m_grand_prix_rank_reward;
        public IFFFile<GrandPrixSpecialHole> m_grand_prix_special_hole;
        public IFFFile<MemorialShopRareItem> m_memorial_shop_rare_item;
        public IFFFile<Models.Data.CaddieVoiceTable> m_caddie_voice_table;
        public IFFFile<FurnitureAbility> m_furniture_ability;
        public IFFFile<Models.Data.TwinsItemTable> m_twins_item_table;
        string PATH_PANGYA_IFF = "data/pangya_gb.iff";
        bool m_loaded;
        sIFFHandle()
        {
            m_loaded = false;

            load();
        }
        public sIFFHandle(string data)
        {
            PATH_PANGYA_IFF = data;
            m_loaded = false;

            load();
        }
        ~sIFFHandle()
        {
            m_loaded = false;
        }
        //ref:
        private IFFFile<T> MakeUnzipVector<T>() where T : new()
        {
            IFFFile<T> vectorIFF = new IFFFile<T>();
            try
            {
                if (File.Exists(PATH_PANGYA_IFF))
                {
                    using (ZipArchive zipArchive = ZipFile.OpenRead(PATH_PANGYA_IFF))
                    {
                        foreach (ZipArchiveEntry entry in zipArchive.Entries)
                        {
                            if (entry.FullName.Equals(typeof(T).Name + ".iff", StringComparison.OrdinalIgnoreCase))
                            {
                                using (var stream = entry.Open())
                                {
                                    var memoryStream = new MemoryStream();
                                    stream.CopyTo(memoryStream);

                                    vectorIFF.Load(memoryStream.ToArray());
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return vectorIFF;
        }


        private IFFFile<T> MakeUnzipVector<T>(string iffName) where T : new()
        {
            IFFFile<T> mapIFF = new IFFFile<T>();
            try
            {
                if (File.Exists(PATH_PANGYA_IFF))
                {
                    using (ZipArchive zipArchive = ZipFile.OpenRead(PATH_PANGYA_IFF))
                    {
                        foreach (ZipArchiveEntry entry in zipArchive.Entries)
                        {
                            if (entry.FullName.Equals(iffName, StringComparison.OrdinalIgnoreCase))
                            {
                                using (var stream = entry.Open())
                                {
                                    using (MemoryStream memoryStream = new MemoryStream())
                                    {
                                        stream.CopyTo(destination: memoryStream);

                                        mapIFF.Load(data: memoryStream.ToArray());
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mapIFF;
        }

        public void load()
        {
            try
            {
                if (m_loaded)
                    reset();

                m_achievement = load_achievement();
                m_item = load_item();
                m_mascot = load_mascot();
                m_part = load_part();
                m_aux_part = load_aux_part();
                m_ball = load_ball();
                m_caddie = load_caddie();
                m_caddie_item = load_caddie_item();
                m_cadie_magic_box = load_cadie_magic_box();
                m_cadie_magic_box_random = load_cadie_magic_box_random();
                m_card = load_card();
                m_character = load_character();
                m_club = load_club();
                m_club_set = load_club_set();
                m_course = load_course();
                m_enchant = load_enchant();
                m_furniture = load_furniture();
                m_hair_style = load_hair_style();
                m_match = load_match();
                m_skin = load_skin();
                m_ability = load_ability();
                m_desc = load_desc();
                m_grand_prix_data = load_grand_prix_data();
                m_grand_prix_rank_reward = load_grand_prix_rank_reward();
                m_grand_prix_special_hole = load_grand_prix_special_hole();
                m_memorial_shop_coin_item = load_memorial_shop_coin_item();
                m_memorial_shop_rare_item = load_memorial_shop_rare_item();
                m_counter_item = load_counter_item();

                m_furniture_ability = load_furniture_ability();
                m_level_up_prize_item = load_level_up_prize_item();

                m_set_effect_table = load_set_effect_table();
                m_tiki_point_table = load_tiki_point_table();
                m_tiki_recipe = load_tiki_recipe();
                m_tiki_special_table = load_tiki_special_table();
                m_quest_item = load_quest_item();
                m_quest_stuff = load_quest_stuff();
                m_set_item = load_set_item();

                m_loaded = true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void reset()
        {

        }
        private void reload() { }
        private IFFFile<Achievement> load_achievement()
        {
            return MakeUnzipVector<Achievement>("Achievement.iff");
        }

        private IFFFile<QuestItem> load_quest_item()
        {
            return MakeUnzipVector<QuestItem>("QuestItem.iff");
        }

        private IFFFile<QuestStuff> load_quest_stuff()
        {
            return MakeUnzipVector<QuestStuff>("QuestStuff.iff");
        }

        private IFFFile<CounterItem> load_counter_item()
        {
            return MakeUnzipVector<CounterItem>("CounterItem.iff");
        }

        private IFFFile<Item> load_item()
        {
            return MakeUnzipVector<Item>("Item.iff");
        }

        private IFFFile<Part> load_part()
        {
            return MakeUnzipVector<Part>("Part.iff");
        }

        private IFFFile<AuxPart> load_aux_part()
        {
            return MakeUnzipVector<AuxPart>("AuxPart.iff");
        }

        private IFFFile<Ball> load_ball()
        {
            return MakeUnzipVector<Ball>("Ball.iff");
        }

        private IFFFile<Caddie> load_caddie()
        {
            return MakeUnzipVector<Caddie>("Caddie.iff");
        }

        private IFFFile<CaddieItem> load_caddie_item()
        {
            return MakeUnzipVector<CaddieItem>("CaddieItem.iff");
        }

        private IFFFile<CadieMagicBox> load_cadie_magic_box()
        {
            return MakeUnzipVector<CadieMagicBox>();
        }

        private IFFFile<CadieMagicBoxRandom> load_cadie_magic_box_random()
        {
            return MakeUnzipVector<CadieMagicBoxRandom>();
        }

        private IFFFile<Card> load_card()
        {
            return MakeUnzipVector<Card>("Card.iff");
        }

        private IFFFile<Character> load_character()
        {
            return MakeUnzipVector<Character>("Character.iff");
        }

        private IFFFile<CharacterMastery> load_character_mastery()
        {
            return MakeUnzipVector<CharacterMastery>();
        }

        private IFFFile<Club> load_club()
        {
            return MakeUnzipVector<Club>("Club.iff");
        }

        private IFFFile<ClubSet> load_club_set()
        {
            return MakeUnzipVector<ClubSet>("ClubSet.iff");
        }

        private IFFFile<ClubSetWorkShopLevelUpLimit> load_club_set_work_shop_level_up_limit()
        {
            return MakeUnzipVector<ClubSetWorkShopLevelUpLimit>();
        }

        private IFFFile<ClubSetWorkShopLevelUpProb> load_club_set_work_shop_level_up_prob()
        {
            return MakeUnzipVector<ClubSetWorkShopLevelUpProb>("ClubSetWorkShopLevelUpProb.iff");
        }

        private IFFFile<ClubSetWorkShopRankUpExp> load_club_set_work_shop_rank_up_exp()
        {
            return MakeUnzipVector<ClubSetWorkShopRankUpExp>("ClubSetWorkShopRankUpExp.iff");
        }

        private IFFFile<Course> load_course()
        {
            return MakeUnzipVector<Course>("Course.iff");
        }

        private IFFFile<CutinInformation> load_cutin_infomation()
        {
            return MakeUnzipVector<CutinInformation>("CutinInfomation.iff");
        }

        private IFFFile<Enchant> load_enchant()
        {
            return MakeUnzipVector<Enchant>("Enchant.iff");
        }

        private IFFFile<Furniture> load_furniture()
        {
            return MakeUnzipVector<Furniture>("Furniture.iff");
        }

        private IFFFile<HairStyle> load_hair_style()
        {
            return MakeUnzipVector<HairStyle>("HairStyle.iff");
        }

        private IFFFile<Match> load_match()
        {
            return MakeUnzipVector<Match>("Match.iff");
        }

        private IFFFile<Skin> load_skin()
        {
            return MakeUnzipVector<Skin>("Skin.iff");
        }

        private IFFFile<Ability> load_ability()
        {
            return MakeUnzipVector<Ability>("Ability.iff");
        }

        private IFFFile<Desc> load_desc()
        {
            return MakeUnzipVector<Desc>("Desc.iff");
        }

        private IFFFile<GrandPrixAIOptionalData> load_grand_prix_ai_optional_data()
        {
            return MakeUnzipVector<GrandPrixAIOptionalData>("GrandPrixAIOptionalData.sff");
        }

        private IFFFile<GrandPrixConditionEquip> load_grand_prix_condition_equip()
        {
            return MakeUnzipVector<GrandPrixConditionEquip>("GrandPrixConditionEquip.iff");
        }

        private IFFFile<GrandPrixData> load_grand_prix_data()
        {
            return MakeUnzipVector<GrandPrixData>("GrandPrixData.iff");
        }

        private IFFFile<GrandPrixRankReward> load_grand_prix_rank_reward()
        {
            return MakeUnzipVector<GrandPrixRankReward>();
        }

        private IFFFile<GrandPrixSpecialHole> load_grand_prix_special_hole()
        {
            return MakeUnzipVector<GrandPrixSpecialHole>();
        }

        private IFFFile<MemorialShopCoinItem> load_memorial_shop_coin_item()
        {
            return MakeUnzipVector<MemorialShopCoinItem>("MemorialShopCoinItem.sff");
        }

        private IFFFile<MemorialShopRareItem> load_memorial_shop_rare_item()
        {
            return MakeUnzipVector<MemorialShopRareItem>();
        }

        private IFFFile<AddonPart> load_addon_part()
        {
            return MakeUnzipVector<AddonPart>();
        }

        private IFFFile<ArtifactManaInfo> load_artifact_mana_info()
        {
            return MakeUnzipVector<ArtifactManaInfo>("ArtifactManaInfo.iff");
        }

        private IFFFile<CaddieVoiceTable> load_caddie_voice_table()
        {
            return MakeUnzipVector<CaddieVoiceTable>();
        }

        private IFFFile<ErrorCodeInfo> load_error_code_info()
        {
            return MakeUnzipVector<ErrorCodeInfo>("ErrorCodeInfo.iff");
        }

        private IFFFile<FurnitureAbility> load_furniture_ability()
        {
            return MakeUnzipVector<FurnitureAbility>();
        }

        private IFFFile<HoleCupDropItem> load_hole_cup_drop_item()
        {
            return MakeUnzipVector<HoleCupDropItem>("HoleCupDropItem.iff");
        }

        private IFFFile<LevelUpPrizeItem> load_level_up_prize_item()
        {
            return MakeUnzipVector<LevelUpPrizeItem>("LevelUpPrizeItem.iff");
        }

        private IFFFile<NonVisibleItemTable> load_non_visible_item_table()
        {
            return MakeUnzipVector<NonVisibleItemTable>("NonVisibleItemTable.iff");
        }

        private IFFFile<PointShop> load_point_shop()
        {
            return MakeUnzipVector<PointShop>("PointShop.iff");
        }

        private IFFFile<ShopLimitItem> load_shop_limit_item()
        {
            return MakeUnzipVector<ShopLimitItem>("ShopLimitItem.iff");
        }

        private IFFFile<SpecialPrizeItem> load_special_prize_item()
        {
            return MakeUnzipVector<SpecialPrizeItem>("SpecialPrizeItem.iff");
        }

        private IFFFile<SubscriptionItemTable> load_subscription_item_table()
        {
            return MakeUnzipVector<SubscriptionItemTable>("SubscriptionItemTable.iff");
        }

        private IFFFile<SetEffectTable> load_set_effect_table()
        {
            return MakeUnzipVector<SetEffectTable>("SetEffectTable.iff");
        }

        private IFFFile<TikiPointTable> load_tiki_point_table()
        {
            return MakeUnzipVector<TikiPointTable>("TikiPointTable.iff");
        }

        private IFFFile<TikiRecipe> load_tiki_recipe()
        {
            return MakeUnzipVector<TikiRecipe>("TikiRecipe.iff");
        }

        private IFFFile<TikiSpecialTable> load_tiki_special_table()
        {
            return MakeUnzipVector<TikiSpecialTable>("TikiSpecialTable.iff");
        }

        private IFFFile<TimeLimitItem> load_time_limit_item()
        {
            return MakeUnzipVector<TimeLimitItem>("TimeLimitItem.iff");
        }

        private IFFFile<TwinsItemTable> load_twins_item_table()
        {
            return MakeUnzipVector<TwinsItemTable>();
        }

        private IFFFile<SetItem> load_set_item()
        {
            return MakeUnzipVector<SetItem>("SetItem.iff");
        }

        private IFFFile<Mascot> load_mascot()
        {
            return MakeUnzipVector<Mascot>("Mascot.iff");
        }

        private T MAKE_FIND_MAP_IFF<T>(IFFFile<T> _iff, uint _typeid)
        {
            if (!m_loaded)
            {
                Console.WriteLine("[IFF::Find][Error] IFF not loaded");
                return default;
            }

            try
            {
                return _iff.GetItem(_typeid);
            }
            catch (Exception e)
            {
                Console.WriteLine("[IFF::Find][ErrorSystem] " + e.Message);
            }

            return (T)Activator.CreateInstance(typeof(T));
        }


        public AuxPart findAuxPart(uint _typeid)
        {
            return MAKE_FIND_MAP_IFF(m_aux_part, _typeid);
        }

        public Ball findBall(uint _typeid)
        {
            return MAKE_FIND_MAP_IFF(m_ball, _typeid);
        }

        public Caddie findCaddie(uint _typeid)
        {
            return MAKE_FIND_MAP_IFF(m_caddie, _typeid);
        }

        public CaddieItem findCaddieItem(uint _typeid)
        {
            return MAKE_FIND_MAP_IFF(m_caddie_item, _typeid);
        }

        public CadieMagicBox findCadieMagicBox(uint _seq)
        {
            return MAKE_FIND_MAP_IFF(m_cadie_magic_box, _seq);
        }

        public Card findCard(uint _typeid)
        {
            return MAKE_FIND_MAP_IFF(m_card, _typeid);
        }

        public Character findCharacter(uint _typeid)
        {
            return MAKE_FIND_MAP_IFF(m_character, _typeid);
        }

        public Club findClub(uint _typeid)
        {
            return MAKE_FIND_MAP_IFF(m_club, _typeid);
        }

        public ClubSet findClubSet(uint _typeid)
        {
            return MAKE_FIND_MAP_IFF(m_club_set, _typeid);
        }

        public Achievement findAchievement(uint _typeid)
        {
            return MAKE_FIND_MAP_IFF(m_achievement, _typeid);
        }


        // Find
        public Part findPart(uint _typeid)
        {
            return MAKE_FIND_MAP_IFF(m_part, _typeid);
        }

        public Item findItem(uint _typeid)
        {
            return MAKE_FIND_MAP_IFF(m_item, _typeid);
        }

        public Mascot findMascot(uint _typeid)
        {
            return MAKE_FIND_MAP_IFF(m_mascot, _typeid);
        }

        public QuestItem findQuestItem(uint _typeid)
        {
            return MAKE_FIND_MAP_IFF(m_quest_item, _typeid);
        }

        public QuestStuff findQuestStuff(uint _typeid)
        {
            return MAKE_FIND_MAP_IFF(m_quest_stuff, _typeid);
        }

        public SetItem findSetItem(uint _typeid)
        {
            return MAKE_FIND_MAP_IFF(m_set_item, _typeid);
        }


        public Course findCourse(uint _typeid)
        {
            return MAKE_FIND_MAP_IFF(m_course, _typeid);
        }

        public Enchant findEnchant(uint _typeid)
        {
            return MAKE_FIND_MAP_IFF(m_enchant, _typeid);
        }

        public Furniture findFurniture(uint _typeid)
        {
            return MAKE_FIND_MAP_IFF(m_furniture, _typeid);
        }

        public HairStyle findHairStyle(uint _typeid)
        {
            return MAKE_FIND_MAP_IFF(m_hair_style, _typeid);
        }

        public Match findMatch(uint _typeid)
        {
            return MAKE_FIND_MAP_IFF(m_match, _typeid);
        }

        public Skin findSkin(uint _typeid)
        {
            return MAKE_FIND_MAP_IFF(m_skin, _typeid);
        }

        public Ability findAbility(uint _typeid)
        {
            return MAKE_FIND_MAP_IFF(m_ability, _typeid);
        }

        public Desc findDesc(uint _typeid)
        {
            return MAKE_FIND_MAP_IFF(m_desc, _typeid);
        }

        public GrandPrixData findGrandPrixData(uint _typeid)
        {
            return MAKE_FIND_MAP_IFF(m_grand_prix_data, _typeid);
        }

        public MemorialShopCoinItem findMemorialShopCoinItem(uint _typeid)
        {
            return MAKE_FIND_MAP_IFF(m_memorial_shop_coin_item, _typeid);
        }

        public LevelUpPrizeItem findLevelUpPrizeItem(uint _level)
        {
            return MAKE_FIND_MAP_IFF(m_level_up_prize_item, _level);
        }

        public SetEffectTable findSetEffectTable(uint _id)
        {
            return MAKE_FIND_MAP_IFF(m_set_effect_table, _id);
        }

        public TikiPointTable findTikiPointTable(uint _id)
        {
            return MAKE_FIND_MAP_IFF(m_tiki_point_table, _id);
        }

        public TikiRecipe findTikiRecipe(uint _id)
        {
            return MAKE_FIND_MAP_IFF(m_tiki_recipe, _id);
        }

        public CadieMagicBoxRandom findCadieMagicBoxRandom(uint _id)
        {
            return MAKE_FIND_MAP_IFF(m_cadie_magic_box_random, _id);
        }
        public MemorialShopRareItem findMemorialShopRareItem(uint _gacha_num)
        {
            return MAKE_FIND_MAP_IFF(m_memorial_shop_rare_item, _gacha_num);
        }


        public bool ItemEquipavel(uint _typeid)
        {
            return Convert.ToBoolean(((_typeid & 0xFE000000) >> 25) & 3);
        }

        public bool IsCanOverlapped(uint _typeid)
        {



            return false;
        }

        private uint getItemGroupIdentify(uint _typeid)
        {
            return Convert.ToUInt32(((_typeid & 0xFC000000) >> 26));
        }

        public bool IsBuyItem(uint _typeid)
        {

            var commom = findCommomItem(_typeid);

            if (commom != null)
                return (commom.Active == 1 && commom.Shop.flag_shop.is_saleable);

            return false;
        }

        public IFFCommon findCommomItem(uint typeid)
        {
            throw new NotImplementedException();
        }

        public bool IsGiftItem(uint _typeid)
        {
            var commom = findCommomItem(_typeid);

            // É saleable ou giftable nunca os 2 juntos por que é a flag composta Somente Purchase(compra)
            // então faço o xor nas 2 flag se der o valor de 1 é por que ela é um item que pode presentear
            // Ex: 1 + 1 = 2 Não é
            // Ex: 1 + 0 = 1 OK
            // Ex: 0 + 1 = 1 OK
            // Ex: 0 + 0 = 0 Não é
            if (commom != null)
                return (commom.Active == 1 && commom.Shop.flag_shop.IsCash
                    && (commom.Shop.flag_shop.is_saleable ^ commom.Shop.flag_shop.IsGift));

            return false;
        }

        public bool IsOnlyDisplay(uint _typeid)
        {
            var commom = findCommomItem(_typeid);

            if (commom != null)
                return (commom.Active == 1 && commom.Shop.flag_shop.IsDisplay);

            return false;
        }

        public bool IsOnlyPurchase(uint _typeid)
        {
            var commom = findCommomItem(_typeid);

            if (commom != null)
                return (commom.Active == 1 && commom.Shop.flag_shop.is_saleable
                    && commom.Shop.flag_shop.IsGift);

            return false;
        }

        public bool IsOnlyGift(uint _typeid)
        {
            var commom = findCommomItem(_typeid);

            if (commom != null)
                return (commom.Active == 1 && commom.Shop.flag_shop.IsCash
                    && commom.Shop.flag_shop.IsGift && commom.Shop.flag_shop.is_saleable);

            return false;
        }



        public IFFFile<Achievement> getAchievement()
        {
            return m_achievement;
        }

        public IFFFile<QuestItem> getQuestItem()
        {
            return m_quest_item;
        }
        public IFFFile<Item> getItem()
        {
            return m_item;
        }

        public IFFFile<Card> getCard()
        {
            return m_card;
        }

        public IFFFile<Skin> getSkin()
        {
            return m_skin;
        }

        public IFFFile<AuxPart> getAuxPart()
        {
            return m_aux_part;
        }

        public IFFFile<Ball> getBall()
        {
            return m_ball;
        }

        public IFFFile<Character> getCharacter()
        {
            return m_character;
        }

        public IFFFile<Caddie> getCaddie()
        {
            return m_caddie;
        }

        public IFFFile<CaddieItem> getCaddieItem()
        {
            return m_caddie_item;
        }

        public IFFFile<CadieMagicBox> getCadieMagicBox()
        {
            return m_cadie_magic_box;
        }

        public IFFFile<ClubSet> getClubSet()
        {
            return m_club_set;
        }

        public IFFFile<HairStyle> getHairStyle()
        {
            return m_hair_style;
        }

        public IFFFile<Part> getPart()
        {
            return m_part;
        }

        public IFFFile<Mascot> getMascot()
        {
            return m_mascot;
        }

        public IFFFile<SetItem> getSetItem()
        {
            return m_set_item;
        }

        public IFFFile<Desc> getDesc()
        {
            return m_desc;
        }

        public IFFFile<LevelUpPrizeItem> getLevelUpPrizeItem()
        {
            return m_level_up_prize_item;
        }

        public IFFFile<MemorialShopCoinItem> getMemorialShopCoinItem()
        {
            return m_memorial_shop_coin_item;
        }

        public IFFFile<MemorialShopRareItem> getMemorialShopRareItem()
        {
            return m_memorial_shop_rare_item;
        }

        public IFFFile<Course> getCourse()
        {
            return m_course;
        }

        public IFFFile<GrandPrixData> getGrandPrixData()
        {
            return m_grand_prix_data;
        }

        public IFFFile<Ability> getAbility()
        {
            return m_ability;
        }

        public IFFFile<SetEffectTable> getSetEffectTable()
        {
            return m_set_effect_table;
        }

        public IFFFile<QuestStuff> getQuestStuff()
        {
            return m_quest_stuff;
        }

        public IFFFile<Club> getClub()
        {
            return m_club;
        }

        public IFFFile<Enchant> getEnchant()
        {
            return m_enchant;
        }

        public IFFFile<Furniture> getFurniture()
        {
            return m_furniture;
        }

        public IFFFile<Match> getMatch()
        {
            return m_match;
        }

        public IFFFile<TikiPointTable> getTikiPointTable()
        {
            return m_tiki_point_table;
        }

        public IFFFile<TikiRecipe> getTikiRecipe()
        {
            return m_tiki_recipe;
        }

        public IFFFile<TikiSpecialTable> getTikiSpecialTable()
        {
            return m_tiki_special_table;
        }

        public IFFFile<CadieMagicBoxRandom> getCadieMagicBoxRandom()
        {
            return m_cadie_magic_box_random;
        }

        public IFFFile<GrandPrixRankReward> getGrandPrixRankReward()
        {
            return m_grand_prix_rank_reward;
        }

        public IFFFile<GrandPrixSpecialHole> getGrandPrixSpecialHole()
        {
            return m_grand_prix_special_hole;
        }

        public IFFFile<FurnitureAbility> getFurnitureAbility()
        {
            return m_furniture_ability;
        }

    }
}
