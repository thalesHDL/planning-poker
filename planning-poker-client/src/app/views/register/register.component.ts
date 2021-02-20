import { Component } from "@angular/core";
import { Router } from "@angular/router";
import { GameService } from "src/app/core/services/game.service";

@Component({
    selector: 'app-register',
    templateUrl: './register.component.html',
    styleUrls: ['./register.component.sass']
})
export class RegisterComponent {

    constructor(private router: Router, private gameService: GameService) {}

    createGame() {
        this.gameService.createGame()
            .catch(error => console.log(error));
    }

    return() {
        this.router.navigate(['']);
    }
}
