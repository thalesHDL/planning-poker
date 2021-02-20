import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { Observable } from "rxjs";
import { GameService } from "src/app/core/services/game.service";
import { GameStore } from "src/app/core/store/game.store";
import { Game } from "src/app/models/entities/game.entity";


@Component({
    selector: 'app-game',
    templateUrl: './game.component.html',
    styleUrls: ['game.component.sass']
})
export class GameComponent implements OnInit {
    inpName: string = "";

    constructor(private route: ActivatedRoute,
                private service: GameService, 
                private store: GameStore) {}

    onKey(event: any) {this.inpName = event.target.value;}
    
    ngOnInit(): void {
        const gameId = this.route.snapshot.paramMap.get('id');
        gameId != undefined ? this.store.update({id: gameId.toString()}) : {};
    }

    get shouldRegister() {
        return this.store.game.playerId == undefined;
    }

    registerUser() {
        this.store.update({playerName: this.inpName});
        const gameId = this.store.game.id;
        
        alert("Esta funcionando so até aqui, ja implementei algumas funcionalidades que são da proxima parte, mas aqui da um erro que creio ser de serializacao, deserializacao, que não deu tempo de arrumar")
        // Error no join, fazer um serializador e deserializar personalizado
        // gameId != undefined ? this.service.joinGame(gameId) : {}; 
    }
}
