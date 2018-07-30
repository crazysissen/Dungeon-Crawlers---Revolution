using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

abstract class Room
{
    public bool explored;
}

abstract class BattleRoom : Room
{

}

class NormalBattle : BattleRoom
{

}

class MiniBossBattle : BattleRoom
{

}

class BossBattle : BattleRoom
{



}

