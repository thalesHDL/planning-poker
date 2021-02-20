import { Injectable } from "@angular/core";
import { environment } from '../../../environments/environment';
import { GameMessage } from "src/app/models/dto/game-message.dto";
import { GameClientEventType } from "src/app/models/enums/game-client-event-type.enum";
import { GameServerEventType } from "src/app/models/enums/game-server-event-type.enum";
import { Hub } from "../hub/hub";
import { Router } from "@angular/router";
import { GameStore } from "../store/game.store";
import { List, Map } from "immutable";

@Injectable()
export class GameService {
    onGameNew(gameId: string) {
        this.store.update({
            id: gameId, 
            isMaster: true,
            gameUrl: `${environment.apiUrl}/game/${gameId}`
        });
        this.router.navigate(['game', gameId])
    }
    onGameNewStory(story: string) {
        this.store.update({
            story: story,
            votedPlayers: List.of<string>(),
            votes: undefined,
            cards: List.of<string>(),
            selectedCard: undefined,
        });
    }
    onGameReveal() {
        // TODO: enviar o card selecionado
    }
    onGameReset() {
        this.store.update({
            votedPlayers: List.of<string>(),
            votes: undefined,
            cards: List.of<string>(),
            selectedCard: undefined,
        });
    }
    onPlayerRegister(playerId: string) {
        this.store.update({playerId: playerId});
    }
    onPlayerJoin(playerId: string) {
        // TODO: add player na lista de players
    }
    onPlayerLeave(playerId: string) {
        // TODO: remove player da lista de players
    }
    onVotePrivate(playerId: string) {
        
    }
    onVotePublic(playerId: string, cardId: string) {
        // TODO: atualizar os votos
    }

    registerEvents() {
        this.hub.assign(GameClientEventType.GAME_NEW, (gameId: string) => this.onGameNew(gameId));
        this.hub.assign(GameClientEventType.GAME_NEW_STORY, (story: string) => this.onGameNewStory(story));
        this.hub.assign(GameClientEventType.GAME_REVEAL, () => this.onGameReveal());
        this.hub.assign(GameClientEventType.GAME_RESET, () => this.onGameReset());
        this.hub.assign(GameClientEventType.PLAYER_REGISTER, (playerId: string) => this.onPlayerRegister(playerId));
        this.hub.assign(GameClientEventType.PLAYER_JOIN, (playerId: string) => this.onPlayerJoin(playerId));
        this.hub.assign(GameClientEventType.PLAYER_LEAVE, (playerId: string) => this.onPlayerLeave(playerId));
        this.hub.assign(GameClientEventType.VOTE_PRIVATE, (playerId: string) => this.onVotePrivate(playerId));
        this.hub.assign(GameClientEventType.VOTE_PUBLIC, (playerId: string, cardId: string) => this.onVotePublic(playerId, cardId));
    }

    constructor(private hub: Hub, private router: Router, private store: GameStore) {
        this.hub.connect(environment.hubUrl);
        this.registerEvents();
        this.hub.start();
    }

    sendMessage(message: GameMessage) {
        return this.hub.invoke(GameServerEventType.SEND_MESSAGE, message);
    }

    createGame() {
        return this.hub.invoke(GameServerEventType.CREATE_GAME);
    }

    joinGame(gameId: string) {
        return this.hub.invoke(GameServerEventType.JOIN_GAME, {gameId: gameId});
    }
}
