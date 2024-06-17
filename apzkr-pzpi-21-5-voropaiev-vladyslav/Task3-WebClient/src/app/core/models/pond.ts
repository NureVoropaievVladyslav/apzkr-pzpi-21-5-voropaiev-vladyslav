export enum FishSpecies {
    Bass,
    Carp,
    Salmon,
    Catfish,
    Tilapia,
    Pike,
    Bluegill,
    Crappie,
    Sturgeon,
    Trout
}

export interface Pond {
    id: string;
    fishSpecies: FishSpecies;
    fishPopulation: number;
    feedingScheduleId: string | undefined;
    createdAt: Date;
}