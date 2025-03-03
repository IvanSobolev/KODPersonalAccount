import React from 'react';
import { Link } from 'react-router-dom';
import { BottomNavigation, BottomNavigationAction } from '@mui/material';
import PersonIcon from '@mui/icons-material/Person';
import GroupIcon from '@mui/icons-material/Group';

const Navbar = () => {
    const [value, setValue] = React.useState(0);

    return (
        <BottomNavigation
            value={value}
            onChange={(event, newValue) => {
                setValue(newValue);
            }}
            showLabels
        >
            <BottomNavigationAction label="Профиль" icon={<PersonIcon />} component={Link} to="/profile" />
            <BottomNavigationAction label="Группы" icon={<GroupIcon />} component={Link} to="/groups" />
        </BottomNavigation>
    );
};

export default Navbar;