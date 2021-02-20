export class GameMessage {
    constructor(public gameId: string,
                public eventType: string,
                public payload: any) {}
}
