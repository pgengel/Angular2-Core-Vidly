export interface MembershipType{
    payAsYouGo : number;
    monthly : number; 
    quartly : number; 
    yearly : number; 
}

export interface Subscription{
    id: number;
    name: string;
    isSubscribedToNewsLetter: boolean;
    membershipType: MembershipType;
}

export interface SaveSubscription{
    id: number;
    Name: string;
    isSubscribedToNewsLetter: boolean;
    MembershipType: MembershipType;
}