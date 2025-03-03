import React, { useState } from 'react';
import Modal from 'react-modal';
import { Typography, Button, Paper, CircularProgress, TextField, Dialog, DialogTitle, DialogContent, DialogActions } from '@mui/material';
import axios from 'axios';

Modal.setAppElement('#root'); // Указываем корневой элемент для модального окна

const GroupModal = ({ group, lessons, lessonsLoading, lessonsError, onClose }) => {
    const [isAddLessonModalOpen, setIsAddLessonModalOpen] = useState(false); // Состояние для модального окна добавления урока
    const [newLessonTitle, setNewLessonTitle] = useState(''); // Состояние для названия урока
    const [newLessonDate, setNewLessonDate] = useState(''); // Состояние для даты урока
    const [newLessonRecordLink, setNewLessonRecordLink] = useState(''); // Состояние для ссылки на запись
    const [isCreatingLesson, setIsCreatingLesson] = useState(false); // Состояние для загрузки при создании урока
    const [creationError, setCreationError] = useState(null); // Состояние для ошибки при создании урока

    // Обработчик открытия модального окна для добавления урока
    const handleOpenAddLessonModal = () => {
        setIsAddLessonModalOpen(true);
    };

    // Обработчик закрытия модального окна для добавления урока
    const handleCloseAddLessonModal = () => {
        setIsAddLessonModalOpen(false);
        setNewLessonTitle('');
        setNewLessonDate('');
        setNewLessonRecordLink('');
        setCreationError(null);
    };

    // Обработчик создания нового урока
    const handleCreateLesson = async () => {
        if (!newLessonTitle || !newLessonDate) {
            setCreationError('Название и дата урока обязательны');
            return;
        }

        setIsCreatingLesson(true);
        setCreationError(null);

        try {
            // Преобразуем дату в формат ISO 8601 (например, "2025-03-03T18:49:59.195Z")
            const isoDate = new Date(newLessonDate).toISOString();

            const response = await axios.post('http://localhost:8080/lessons', {
                groupId: group.id,
                title: newLessonTitle,
                date: isoDate, // Используем дату в формате ISO 8601
                recordLink: newLessonRecordLink || null,
            });

            // Добавляем новый урок в список уроков
            lessons.push(response.data);
            handleCloseAddLessonModal(); // Закрываем модальное окно
        } catch (err) {
            setCreationError(err.message);
        } finally {
            setIsCreatingLesson(false);
        }
    };

    return (
        <>
            <Modal
                isOpen={!!group}
                onRequestClose={onClose}
                contentLabel="Group Modal"
                style={{
                    content: {
                        top: '50%',
                        left: '50%',
                        right: 'auto',
                        bottom: 'auto',
                        marginRight: '-50%',
                        transform: 'translate(-50%, -50%)',
                        width: '500px',
                        padding: '20px',
                    },
                }}
            >
                <Paper style={{ padding: '20px' }}>
                    <Typography variant="h5" style={{ marginBottom: '20px' }}>
                        {group.name}
                    </Typography>
                    <Typography variant="h6" style={{ marginBottom: '10px' }}>
                        Уроки:
                    </Typography>
                    {lessonsLoading ? (
                        <CircularProgress />
                    ) : lessonsError ? (
                        <Typography color="error">Ошибка: {lessonsError}</Typography>
                    ) : (
                        <ul style={{ listStyle: 'none', padding: 0 }}>
                            {lessons.map((lesson) => (
                                <li key={lesson.id} style={{ marginBottom: '10px' }}>
                                    <Typography>
                                        <strong>Название:</strong> {lesson.title}
                                    </Typography>
                                    {lesson.date && (
                                        <Typography>
                                            <strong>Дата проведения:</strong> {new Date(lesson.date).toLocaleString()}
                                        </Typography>
                                    )}
                                    {lesson.recordLink && (
                                        <Typography>
                                            <strong>Ссылка на запись:</strong>{' '}
                                            <a href={lesson.recordLink} target="_blank" rel="noopener noreferrer">
                                                Перейти к записи
                                            </a>
                                        </Typography>
                                    )}
                                </li>
                            ))}
                        </ul>
                    )}
                    <Button
                        variant="contained"
                        color="primary"
                        onClick={handleOpenAddLessonModal}
                        style={{ marginTop: '20px', marginRight: '10px' }}
                    >
                        Добавить урок
                    </Button>
                    <Button
                        variant="contained"
                        color="secondary"
                        onClick={onClose}
                        style={{ marginTop: '20px' }}
                    >
                        Закрыть
                    </Button>
                </Paper>
            </Modal>

            {/* Модальное окно для добавления урока */}
            <Dialog open={isAddLessonModalOpen} onClose={handleCloseAddLessonModal}>
                <DialogTitle>Добавить новый урок</DialogTitle>
                <DialogContent>
                    <TextField
                        label="Название урока"
                        value={newLessonTitle}
                        onChange={(e) => setNewLessonTitle(e.target.value)}
                        fullWidth
                        margin="normal"
                        required
                    />
                    <TextField
                        label="Дата проведения"
                        type="datetime-local"
                        value={newLessonDate}
                        onChange={(e) => setNewLessonDate(e.target.value)}
                        fullWidth
                        margin="normal"
                        InputLabelProps={{
                            shrink: true,
                        }}
                        required
                    />
                    <TextField
                        label="Ссылка на запись"
                        value={newLessonRecordLink}
                        onChange={(e) => setNewLessonRecordLink(e.target.value)}
                        fullWidth
                        margin="normal"
                    />
                    {creationError && (
                        <Typography color="error" style={{ marginTop: '10px' }}>
                            Ошибка: {creationError}
                        </Typography>
                    )}
                </DialogContent>
                <DialogActions>
                    <Button onClick={handleCloseAddLessonModal} color="secondary">
                        Отмена
                    </Button>
                    <Button onClick={handleCreateLesson} color="primary" disabled={isCreatingLesson}>
                        {isCreatingLesson ? <CircularProgress size={24} /> : 'Создать'}
                    </Button>
                </DialogActions>
            </Dialog>
        </>
    );
};

export default GroupModal;