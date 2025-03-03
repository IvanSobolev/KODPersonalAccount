import React, { useState, useEffect } from 'react';
import { Avatar, Typography, Paper, CircularProgress } from '@mui/material';
import axios from 'axios';

const Profile = () => {
    const [user, setUser] = useState(null); // Состояние для хранения данных о пользователе
    const [loading, setLoading] = useState(true); // Состояние для отображения загрузки
    const [error, setError] = useState(null); // Состояние для обработки ошибок

    // Функция для выполнения GET-запроса
    const fetchUserProfile = async () => {
        try {
            const response = await axios.get('http://localhost:8080/users/getMe'); // Замените на ваш URL
            setUser(response.data); // Сохраняем данные о пользователе
            setLoading(false); // Убираем состояние загрузки
        } catch (err) {
            setError(err.message); // Сохраняем сообщение об ошибке
            setLoading(false); // Убираем состояние загрузки
        }
    };

    // Выполняем запрос при монтировании компонента
    useEffect(() => {
        fetchUserProfile();
    }, []);

    // Если данные загружаются, показываем индикатор загрузки
    if (loading) {
        return (
            <Paper style={{ padding: '20px', margin: '20px', textAlign: 'center' }}>
                <CircularProgress />
            </Paper>
        );
    }

    // Если произошла ошибка, показываем сообщение об ошибке
    if (error) {
        return (
            <Paper style={{ padding: '20px', margin: '20px', textAlign: 'center' }}>
                <Typography variant="h6" color="error">
                    Ошибка: {error}
                </Typography>
            </Paper>
        );
    }

    // Если данные успешно загружены, отображаем профиль пользователя
    return (
        <Paper style={{ padding: '20px', margin: '20px', textAlign: 'center' }}>
            <Avatar
                alt={user.name}
                src={user.avatar}
                style={{ width: '100px', height: '100px', margin: 'auto' }}
            />
            <Typography variant="h4" style={{ marginTop: '10px' }}>
                {user.name}
            </Typography>
            <Typography variant="subtitle1" style={{ marginTop: '5px' }}>
                Телеграм: {user.telegram}
            </Typography>
            <Typography variant="subtitle1" style={{ marginTop: '5px' }}>
                Роль: {user.role}
            </Typography>
            <Typography variant="subtitle1" style={{ marginTop: '5px' }}>
                Баллы: {user.points}
            </Typography>
        </Paper>
    );
};

export default Profile;