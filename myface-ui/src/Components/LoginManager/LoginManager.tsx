﻿import React, { createContext, ReactNode, useState } from "react";

export const LoginContext = createContext<{
    username?: string,
    password?: string,
    isLoggedIn: boolean,
    isAdmin: boolean,
    logIn: (username?: string, password?: string) => void,
    logOut: () => void,
}>({
    isLoggedIn: false,
    isAdmin: false,
    logIn: () => { },
    logOut: () => { },
});

interface LoginManagerProps {
    children: ReactNode
}

export function LoginManager(props: LoginManagerProps): JSX.Element {
    const [loggedIn, setLoggedIn] = useState(true);
    const [username, setUsername] = useState<string>();
    const [password, setPassword] = useState<string>();

    function logIn() {
        setLoggedIn(true);
        setUsername(username);
        setPassword(password);
    }

    function logOut() {
        setLoggedIn(false);
        setUsername(undefined);
        setPassword(undefined);
    }

    const context = {
        username: username,
        password: password,
        isLoggedIn: loggedIn,
        isAdmin: loggedIn,
        logIn: logIn,
        logOut: logOut,
    };

    return (
        <LoginContext.Provider value={context}>
            {props.children}
        </LoginContext.Provider>
    );
}