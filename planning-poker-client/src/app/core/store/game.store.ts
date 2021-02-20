import { Injectable } from "@angular/core";
import { BehaviorSubject, Observable } from "rxjs";
import { Game } from "src/app/models/entities/game.entity";


@Injectable()
export class GameStore {
    private _gameState$: BehaviorSubject<Game> = new BehaviorSubject<Game>(new Game());

    get game() {
        return this._gameState$.value;
    }

    asObservable(): Observable<Game> {
        return this._gameState$.asObservable();
    }

    clearGame(): void {
        this._gameState$.next({

        })
    }

    update(value: Game): void {
        this._gameState$.next({
            ...this._gameState$.value,
            ...value
        });
    }
}
