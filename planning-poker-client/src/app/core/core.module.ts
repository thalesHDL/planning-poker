import { NgModule } from "@angular/core";
import { Hub } from "./hub/hub";
import { SignalRHub } from "./hub/signal-r.hub.";
import { GameService } from "./services/game.service";
import { GameStore } from "./store/game.store";

@NgModule({
    providers: [
        {provide: Hub, useClass: SignalRHub},
        {provide: GameService},
        {provide: GameStore}
    ]
})
export class CoreModule {}