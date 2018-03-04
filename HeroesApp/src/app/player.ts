import { IDeserializable } from './deserializable.model'
import { Hero } from './hero'
export class Player implements IDeserializable<Player>
{
  id: number;
  name: string;
  winrate: number;
  kdaRatio: number;
  favHero: Hero;

  deserialize(input: any): Player {
    Object.assign(this, input);
    this.favHero = new Hero().deserialize(input.favHero);
    return this;
  }
}
