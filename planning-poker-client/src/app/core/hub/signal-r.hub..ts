import { Injectable } from '@angular/core';
import { HttpTransportType, HubConnection, HubConnectionBuilder, HubConnectionState, LogLevel } from '@microsoft/signalr';
import { BehaviorSubject } from 'rxjs';
import { Hub } from './hub';


@Injectable()
export class SignalRHub implements Hub {
    protected _connection!: HubConnection;
    protected _connectionEstablished$ = new BehaviorSubject<boolean>(false);

    public connectionId(): string|null {
        return this._connection.connectionId;
    }

    public async connect(hubUrl: string) {
        this._connection = new HubConnectionBuilder()
            .withUrl(hubUrl, {
                skipNegotiation: true,
                transport: HttpTransportType.WebSockets,
                logger: LogLevel.Critical,
                logMessageContent: true
            })
            .build();
    }

    public async start() {
        if (this._connection.state === HubConnectionState.Connected)
            return;
        
        this._connection.start()
            .then(() => {
                console.log('Hub connection started!');
                this._connectionEstablished$.next(true);
            }).catch(error => {
                console.error(error);
            });
    }

    public async send(eventId: string, ...message: any[]) {
        return this._connection.send(eventId, message);
    }

    public assign(eventId: string, eventCallback: (...args: any[]) => any) {
        this._connection.on(eventId, eventCallback);
    }

    public invoke(methodName: string, ...args: any[]): Promise<any> {
        if (args.length == 0)
            return this._connection.invoke(methodName);
        else
            return this._connection.invoke(methodName, args);
    } 

    public isConnected() {
        return this._connectionEstablished$.value;
    }
}
