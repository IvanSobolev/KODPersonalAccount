import React, { useState } from 'react';
import Modal from 'react-modal';
import { TextField, Button, Paper } from '@mui/material';

const AddLessonModal = ({ onClose }) => {
    const [lessonName, setLessonName] = useState('');
    const [lessonDate, setLessonDate] = useState('');
    const [lessonLink, setLessonLink] = useState('');

    const handleSubmit = () => {
        // Здесь можно добавить логику для сохранения урока
        onClose();
    };

    return (
        <Modal isOpen={true} onRequestClose={onClose} contentLabel="Add Lesson Modal">
            <Paper style={{ padding: '20px', margin: '20px' }}>
                <TextField
                    label="Название урока"
                    value={lessonName}
                    onChange={(e) => setLessonName(e.target.value)}
                    fullWidth
                    margin="normal"
                />
                <TextField
                    label="Дата проведения"
                    type="date"
                    value={lessonDate}
                    onChange={(e) => setLessonDate(e.target.value)}
                    fullWidth
                    margin="normal"
                    InputLabelProps={{
                        shrink: true,
                    }}
                />
                <TextField
                    label="Ссылка на видеозапись"
                    value={lessonLink}
                    onChange={(e) => setLessonLink(e.target.value)}
                    fullWidth
                    margin="normal"
                />
                <Button variant="contained" color="primary" onClick={handleSubmit}>
                    Сохранить
                </Button>
                <Button variant="contained" color="secondary" onClick={onClose}>
                    Отмена
                </Button>
            </Paper>
        </Modal>
    );
};

export default AddLessonModal;