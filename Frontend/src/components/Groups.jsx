import React, { useState, useEffect } from 'react';
import { List, ListItem, ListItemText, Paper, Typography, CircularProgress } from '@mui/material';
import axios from 'axios';
import GroupModal from './GroupModal';

const Groups = () => {
    const [groups, setGroups] = useState([]); // Состояние для хранения списка групп
    const [loading, setLoading] = useState(true); // Состояние для отображения загрузки
    const [error, setError] = useState(null); // Состояние для обработки ошибок
    const [selectedGroup, setSelectedGroup] = useState(null); // Состояние для выбранной группы
    const [lessons, setLessons] = useState([]); // Состояние для хранения уроков выбранной группы
    const [lessonsLoading, setLessonsLoading] = useState(false); // Состояние для загрузки уроков
    const [lessonsError, setLessonsError] = useState(null); // Состояние для ошибок при загрузке уроков

    // Функция для выполнения GET-запроса для получения списка групп
    const fetchGroups = async () => {
        try {
            const response = await axios.get('http://localhost:8080/groups'); // URL для получения групп
            setGroups(response.data); // Сохраняем данные о группах
            setLoading(false); // Убираем состояние загрузки
        } catch (err) {
            setError(err.message); // Сохраняем сообщение об ошибке
            setLoading(false); // Убираем состояние загрузки
        }
    };

    // Функция для выполнения GET-запроса для получения уроков по groupId
    const fetchLessons = async (groupId) => {
        setLessonsLoading(true); // Включаем состояние загрузки уроков
        setLessonsError(null); // Сбрасываем ошибки
        try {
            const response = await axios.get(`http://localhost:8080/lessons?groupId=${groupId}`);
            setLessons(response.data); // Сохраняем данные об уроках
        } catch (err) {
            setLessonsError(err.message); // Сохраняем сообщение об ошибке
        } finally {
            setLessonsLoading(false); // Выключаем состояние загрузки уроков
        }
    };

    // Выполняем запрос при монтировании компонента
    useEffect(() => {
        fetchGroups();
    }, []);

    // Обработчик клика по группе
    const handleGroupClick = async (group) => {
        setSelectedGroup(group); // Устанавливаем выбранную группу
        await fetchLessons(group.id); // Загружаем уроки для выбранной группы
    };

    // Закрытие модального окна
    const handleCloseModal = () => {
        setSelectedGroup(null); // Сбрасываем выбранную группу
        setLessons([]); // Очищаем список уроков
        setLessonsError(null); // Сбрасываем ошибки
    };

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

    // Если данные успешно загружены, отображаем список групп
    return (
        <Paper style={{ padding: '20px', margin: '20px' }}>
            <Typography variant="h4" align="center" style={{ marginBottom: '20px' }}>
                Группы
            </Typography>
            <List>
                {groups.map((group) => (
                    <ListItem button key={group.id} onClick={() => handleGroupClick(group)}>
                        <ListItemText
                            primary={group.name}
                            secondary={
                                <>
                                    <Typography component="span" variant="body2" display="block">
                                        Направление: {group.direction}
                                    </Typography>
                                    <Typography component="span" variant="body2" display="block">
                                        Расписание: {group.schedule}
                                    </Typography>
                                    {group.teacherId && (
                                        <Typography component="span" variant="body2" display="block">
                                            ID педагога: {group.teacherId}
                                        </Typography>
                                    )}
                                </>
                            }
                        />
                    </ListItem>
                ))}
            </List>
            {selectedGroup && (
                <GroupModal
                    group={selectedGroup}
                    lessons={lessons}
                    lessonsLoading={lessonsLoading}
                    lessonsError={lessonsError}
                    onClose={handleCloseModal}
                />
            )}
        </Paper>
    );
};

export default Groups;