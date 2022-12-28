import { DatePipe } from '@angular/common';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { CardTypesModule } from './card-types/card-types.module';
import { CardModule } from './card/card.module';
import { LoginModule } from './Login/login.module';
import { SharedModule } from './shared/shared.module';

@NgModule({
  declarations: [AppComponent],
  imports: [SharedModule, CardModule, LoginModule, CardTypesModule],
  providers: [DatePipe],
  bootstrap: [AppComponent],
})
export class AppModule {}
