import { IDeserializable } from './deserializable.model'

export class Map implements IDeserializable<Map>
{
  id: number;
  name: string;
  fullName: string;

  deserialize(input: any): Map {
    Object.assign(this, input);
    return this;
  }

  getPreviewPath(): string {
    return "assets/maps/" + this.name + ".png";
  }
}
