import { List, Map } from "node_modules/immutable";

export class Game {
    constructor(public id?: string,
                public title?: string,
                public story?: string,
                public playersIds?: List<string>,
                public playersNames?: List<string>,
                public votedPlayers?: List<string>,
                public votes?: Map<string, string>, // <USER_ID, CARD_ID>
                public cards?: List<string>,
                public isMaster?: boolean,
                public selectedCard?: string,
                public gameUrl?: string,
                public playerId?: string,
                public playerName?: string) {}
}
