import { Device } from './device';

export interface DeviceDetails {
    id: number;
    name: string;
    status: string;
    photoUrl: string;
    temperature: string;
    relatedDevices: Device[];
    usageList: number[];
}