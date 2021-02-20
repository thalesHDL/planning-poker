import { Injectable } from "@angular/core";

@Injectable()
export abstract class Hub {
    public abstract connect: (hubUrl: string)=> Promise<void>;
    public abstract start: () => Promise<void>;
    public abstract send: (eventId: string, ...args: any[]) => Promise<any>;
    public abstract assign: (eventId: string, eventCallback: (...args: any[]) => void) => void;
    public abstract invoke: (methodName: string, ...args: any[]) => Promise<any>;
    public abstract isConnected(): boolean;
    public abstract connectionId(): string|null;
}
