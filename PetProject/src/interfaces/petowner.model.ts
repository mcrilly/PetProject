import { Pet } from "./pet.model";

export interface PetOwner {
    name: string;
    age: number;
    gender: string;

    pets?: Pet[];
}
