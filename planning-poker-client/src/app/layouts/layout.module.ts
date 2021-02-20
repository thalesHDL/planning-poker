import { CommonModule } from "@angular/common";
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { PrivateLayoutComponent } from "./private/private-layout.component";
import { PublicLayoutComponent } from "./public/public-layout.component";

@NgModule({
    declarations: [
        PrivateLayoutComponent,
        PublicLayoutComponent
    ],
    imports: [
        CommonModule,
        RouterModule.forChild([])
    ],
    exports: [
        PrivateLayoutComponent,
        PublicLayoutComponent
    ],
    schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class LayoutModule {}
