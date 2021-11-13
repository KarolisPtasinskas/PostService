import { ParcelMachine } from './parcelMachine';

export interface Parcel {
  id?: number;
  weight: string;
  phone: string;
  description: string;
  parcelMachineId: string;
  parcelMachine?: ParcelMachine;
}
