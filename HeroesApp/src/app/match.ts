import { IDeserializable } from './deserializable.model'
import { Hero } from './hero'
import { Player } from './player'
import { Map } from './map'

export class Match implements IDeserializable<Match>
{
  id: number;
  duration: number;
  map : Map;
  isBlueTeamWon: boolean;
  participants: MatchEntry[];

  blueTeam: MatchEntry[];
  redTeam: MatchEntry[];

  deserialize(input: any): Match {
    Object.assign(this, input);
    this.participants = input.participants.map(p => new MatchEntry().deserialize(p));
    this.map = new Map().deserialize(input.map);
    this.blueTeam = this.participants.filter(p => p.isInBlueTeam);
    this.redTeam = this.participants.filter(p => !p.isInBlueTeam);

    return this;
  }
}

export class MatchEntry implements IDeserializable<MatchEntry> {

  hero: Hero;
  player: Player;
  kills: number;
  assists: number;
  deaths: number;
  isInBlueTeam: boolean;

  kda: number;

  deserialize(input: any): MatchEntry {
    Object.assign(this, input);
    this.hero = new Hero().deserialize(input.hero);
    this.player = new Player().deserialize(input.player);

    this.kda = (this.kills + this.assists) / this.deaths;

    return this;
  }
}
