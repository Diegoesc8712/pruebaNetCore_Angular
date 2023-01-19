export interface JwtResponseI {
    dataUser:{
        id: number,
        usuario: string,
        password: string,
        estado: number,
        accessToken: string,
        expiresIn: string    
    }
}
