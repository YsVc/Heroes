import { IDeserializable } from './deserializable.model'

export class Hero implements IDeserializable<Hero>
{
  id: number;
  name: string;
  winrate: number;
  popularity: number;
  kdaRatio: number;

  deserialize(input: any): Hero {
    Object.assign(this, input);
    return this;
  }

  getHeroPortraitPath(): string {
    return "assets/heroes/" + this.name + "/hero-portrait.png";
  }
}
