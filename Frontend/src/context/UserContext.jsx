import React, { createContext, useState } from 'react';

// Создаем контекст
export const UserContext = createContext();

// Создаем провайдер контекста
export const UserProvider = ({ children }) => {
    const [user, setUser] = useState({
        avatar: 'https://via.placeholder.com/150',
        name: 'Иван Иванов',
        telegram: '@ivanov',
        role: 'Ученик', // Может быть 'Ученик', 'Педагог', 'Куратор'
        points: 100,
    });

    return (
        <UserContext.Provider value={{ user, setUser }}>
            {children}
        </UserContext.Provider>
    );
};