/**
 * Sample React Native App
 * https://github.com/facebook/react-native
 *
 * @format
 */

import React from 'react';
import type {PropsWithChildren} from 'react';
import {
  SafeAreaView,
  ScrollView,
  StatusBar,
  StyleSheet,
  Text,
  useColorScheme,
  View,
} from 'react-native';

import {
  Colors,
  DebugInstructions,
  Header,
  LearnMoreLinks,
  ReloadInstructions,
} from 'react-native/Libraries/NewAppScreen';
import SignIn from './src/pages/SignIn';
import {
  NavigationContainer,
  useNavigationContainerRef,
} from '@react-navigation/native';
import {createNativeStackNavigator} from '@react-navigation/native-stack';
import {SafeAreaProvider} from 'react-native-safe-area-context';
import CreateAccount from './src/pages/CreateAccount';
import SigninAdult from './src/pages/SigninAdult';
import AdultHomepage from './src/pages/AdultHomePage';
import ChildHomePage from './src/pages/ChildHomePage';
import ChildSignIn from './src/pages/ChildSignIn';

const Stack = createNativeStackNavigator();

function App(): JSX.Element {
  const isDarkMode = useColorScheme() === 'dark';
  const navigationRef = useNavigationContainerRef();
  const backgroundStyle = {
    backgroundColor: isDarkMode ? Colors.darker : Colors.lighter,
  };

  return (
    <SafeAreaProvider>
      <NavigationContainer>
        <Stack.Navigator>
          <Stack.Screen
            name="SignIn"
            component={SignIn}
            options={{headerShown: false}}
          />
          <Stack.Screen
            name="CreateAccount"
            component={CreateAccount}
            options={{headerShown: false}}
          />
          <Stack.Screen
            name="SigninAdult"
            component={SigninAdult}
            options={{headerShown: false}}
          />
          <Stack.Screen
            name="AdultHomepage"
            component={AdultHomepage}
            options={{headerShown: false}}
          />
          <Stack.Screen
            name="ChildHomePage"
            component={ChildHomePage}
            options={{headerShown: false}}
          />
          <Stack.Screen
            name="ChildSignIn"
            component={ChildSignIn}
            options={{headerShown: false}}
          />
        </Stack.Navigator>
      </NavigationContainer>
    </SafeAreaProvider>
  );
}

const styles = StyleSheet.create({
  sectionContainer: {
    marginTop: 32,
    paddingHorizontal: 24,
  },
  sectionTitle: {
    fontSize: 24,
    fontWeight: '600',
  },
  sectionDescription: {
    marginTop: 8,
    fontSize: 18,
    fontWeight: '400',
  },
  highlight: {
    fontWeight: '700',
  },
  container: {
    flex: 1,
    backgroundColor: '#98D8AA',
    alignItems: 'center',
    justifyContent: 'center',
  },
});

export default App;
